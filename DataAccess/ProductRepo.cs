using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http.Headers;
using Entities;
using Microsoft.Data.SqlClient;
using DataAccess.Interfaces;

namespace DataAcces
{
    public class ProductRepo : IProductRepo
    {
        IBaseRepo baseRepo;        
        
        public ProductRepo(IBaseRepo baseRepo   ) 
        {
            this.baseRepo = baseRepo;   
        }
        public Product GetProductById(int id)
        {
            Product product = null;
            string sqlQuery = $"select * from [dbo].[Productos] where Id={id}";
            using (SqlDataReader sqlDataReader = baseRepo.GetFromDataBase(sqlQuery))
            {
                if (sqlDataReader.Read())
                {
                    product = new Product
                    {
                        Id = int.Parse(sqlDataReader["Id"].ToString()),
                        Name = sqlDataReader["Name"].ToString(),
                        Gramaje = int.Parse(sqlDataReader["Gramaje"].ToString()),
                        Costo = double.Parse(sqlDataReader["Costo"].ToString())
                    };
                }
            }
            return product;
        }

        bool IProductRepo.CreateProduct(Product product)
        {
            int id = GetLastIdCreated()+1;
            string sqlQuery = @"INSERT INTO [dbo].[Productos] (Id,Name, Gramaje, Costo, PrecioVenta)VALUES(@Id,@Name, @Gramaje, @Costo, @PrecioVenta)";
            if (CheckIfProductExists(product.Name, product.Gramaje))
            {
                throw new InvalidOperationException("Product Already Exist, Pease Check");
            }

            List<SqlParameter> sqlParameters = new List<SqlParameter>();
            sqlParameters.Add(new SqlParameter("@Id", id));
            sqlParameters.Add(new SqlParameter("@Name", product.Name));
            sqlParameters.Add(new SqlParameter("@Gramaje", product.Gramaje));
            sqlParameters.Add(new SqlParameter("@Costo", product.Costo));
            sqlParameters.Add(new SqlParameter("@PrecioVenta", product.PrecioVenta));

            baseRepo.UpdateInDataBase(sqlQuery, sqlParameters);

            return true;

        }

        private int GetLastIdCreated()
        {
            int lastId = 0;
            string sqlQuery = "SELECT MAX(Id) FROM [dbo].[Productos]";
            using (SqlDataReader sqlDataReader = baseRepo.GetFromDataBase(sqlQuery))
            {
                if (sqlDataReader.Read())
                {
                    var result = sqlDataReader.GetValue(0);
                    if (result != null && result != DBNull.Value)
                    {
                        lastId = Convert.ToInt32(result);
                    }
                }
                return lastId;
            }
        }

        public bool CheckIfProductExists(string name, int gramaje)
        {
            string sqlQuery = @"SELECT COUNT(*) FROM [dbo].[Productos] WHERE Name = @Name AND Gramaje = @Gramaje";
            List<SqlParameter> sqlParameters = new List<SqlParameter>();

            sqlParameters.Add(new SqlParameter("@Name", name));
            sqlParameters.Add(new SqlParameter("@Gramaje", gramaje));
            using (SqlDataReader sqlDataReader = baseRepo.GetFromDataBase(sqlQuery, sqlParameters))
            {
                if (sqlDataReader.Read())
                {
                    int count = Convert.ToInt32(sqlDataReader.GetValue(0));
                    return count > 0;
                }
                return false;
            }
        }

        public bool CheckIfProductExists(int id)
        {
            string sqlQuery = @"SELECT COUNT(*) FROM [dbo].[Productos] WHERE Id = @Id";
            List <SqlParameter> sqlParameters = new List<SqlParameter>();
            sqlParameters.Add(new SqlParameter("@Id", id));
            using (SqlDataReader sqlDataReader=baseRepo.GetFromDataBase(sqlQuery,sqlParameters))
            {
                if (sqlDataReader.Read())
                {
                    int count = Convert.ToInt32(sqlDataReader.GetValue(0));
                    return count > 0;
                }
                return false;
            }


        }

        bool IProductRepo.DeleteProduct(int id)
        {            
            if (!CheckIfProductExists(id))
            {
                throw new InvalidOperationException("El producto no existe.");
            }

            List<SqlParameter> sqlParameters = new List<SqlParameter>();
            string sqlQuery = "DELETE FROM [dbo].[Productos] WHERE Id = @Id";
            sqlParameters.Add(new SqlParameter("@Id", id));
            baseRepo.UpdateInDataBase(sqlQuery, sqlParameters);

            return true;
        }

        List<Product> IProductRepo.GetAllProducts()
        {
            List<Product> products = new List<Product>();
            string sqlQuery = $"select * from [dbo].[Productos]";

            using (SqlDataReader sqlDataReader = baseRepo.GetFromDataBase(sqlQuery))
            {
                while (sqlDataReader.Read())
                {
                    Product producto = new Product
                    {
                        Id = int.Parse(sqlDataReader["Id"].ToString()),
                        Name = sqlDataReader["Name"].ToString(),
                        Gramaje = int.Parse(sqlDataReader["Gramaje"].ToString()),
                        Costo = double.Parse(sqlDataReader["Costo"].ToString())
                    };
                    products.Add(producto);

                }
            }
            return products;
        }

        bool IProductRepo.UpdateProduct(int id, Product product)
        {
            if (!CheckIfProductExists(id))
            {
                throw new InvalidOperationException("Product doesn't exist");
            }
            string sqlQuery = @"update [dbo].[Productos] set Name=@Name, Gramaje=@Gramaje, Costo=@Costo, PrecioVenta=@PrecioVenta where Id=@Id";
            List<SqlParameter> sqlParameters = new List<SqlParameter>();
            sqlParameters.Add(new SqlParameter("@Name", product.Name));
            sqlParameters.Add(new SqlParameter("@Gramaje", product.Gramaje));
            sqlParameters.Add(new SqlParameter("@Costo", product.Costo));
            sqlParameters.Add(new SqlParameter("@PrecioVenta", product.PrecioVenta));
            sqlParameters.Add(new SqlParameter("@Id", id));

            baseRepo.UpdateInDataBase(sqlQuery, sqlParameters);

            return true;
        }

        public double GetProductPrice(int productId)
        {
            double price = 0;
            string sqlQuery = $"Select PrecioVenta from [dbo].[Productos] where id={productId}";
            using (SqlDataReader sqlDataReader = baseRepo.GetFromDataBase(sqlQuery))
            {
                if (sqlDataReader.Read())
                {
                    var result = sqlDataReader.GetValue(0);
                    if (result != null && result != DBNull.Value)
                    {
                        price = Convert.ToDouble(result);
                    }
                }
            }
            return price;
        }
    }
}
