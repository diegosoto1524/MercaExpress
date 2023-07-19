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
        private readonly SqlConnection connection;
        
        public ProductRepo(string conectionString) 
        {
            connection = new SqlConnection(conectionString);
            connection.Open();
        }
        public Product GetProductById(int id)
        {

            Product product = null;
            string sqlQuery = $"select * from [dbo].[Productos] where Id={id}";
            using (SqlCommand sqlCommand = new SqlCommand(sqlQuery, connection))
            using (SqlDataReader sqlDataReader = sqlCommand.ExecuteReader())
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
            string sqlQuery = @"INSERT INTO [dbo].[Productos] (Id,Name, Gramaje, Costo, PrecioVenta, IdProveedor)VALUES(@Id,@Name, @Gramaje, @Costo, @PrecioVenta, @IdProveedor)";
            if (CheckIfProductExists(product.Name, product.Gramaje))
            {
                throw new InvalidOperationException("Product Already Exist, Pease Check");
            }

            using (SqlCommand sqlCommand = new SqlCommand(sqlQuery, connection))
            {
                sqlCommand.Parameters.AddWithValue("@Id", id);                
                sqlCommand.Parameters.AddWithValue("@Name", product.Name);
                sqlCommand.Parameters.AddWithValue("@Gramaje", product.Gramaje);
                sqlCommand.Parameters.AddWithValue("@Costo", product.Costo);
                sqlCommand.Parameters.AddWithValue("@PrecioVenta", product.PrecioVenta);
                sqlCommand.Parameters.AddWithValue("@IdProveedor", product.IdProvedor);
                sqlCommand.ExecuteNonQuery();
                return true;
            }
        }

        private int GetLastIdCreated()
        {
            int lastId = 0;
            string sqlQuery = "SELECT MAX(Id) FROM [dbo].[Productos]";
            using(SqlCommand sqlCommand = new SqlCommand(sqlQuery, connection))
            {
                var result=sqlCommand.ExecuteScalar();
                if(result != null && result != DBNull.Value)
                {
                    lastId = Convert.ToInt32(result);
                }
            }
            return lastId;
        }

        private bool CheckIfProductExists(string name, int gramaje)
        {
            string sqlQuery = @"SELECT COUNT(*) FROM [dbo].[Productos] WHERE Name = @Name AND Gramaje = @Gramaje";
            using (SqlCommand sqlCommand= new SqlCommand(sqlQuery, connection))
            {
                sqlCommand.Parameters.AddWithValue("@Name", name);
                sqlCommand.Parameters.AddWithValue("@Gramaje", gramaje);    
                int count = Convert.ToInt32(sqlCommand.ExecuteScalar());
                return count > 0;
            }

        }

        private bool CheckIfProductExists(int id)
        {
            string sqlQuery = @"SELECT COUNT(*) FROM [dbo].[Productos] WHERE Id = @Id";
            using (SqlCommand sqlCommand = new SqlCommand(sqlQuery, connection))
            {
                sqlCommand.Parameters.AddWithValue("@Id", id);
                int count = Convert.ToInt32(sqlCommand.ExecuteScalar());
                return count > 0;
            }

        }

        bool IProductRepo.DeleteProduct(int id)
        {
            if (!CheckIfProductExists(id))
            { 
                throw new InvalidOperationException("El producto no existe."); 
            }

            string sqlQuery = "DELETE FROM [dbo].[Productos] WHERE Id = @Id";
            using (SqlCommand sqlCommand = new SqlCommand(sqlQuery, connection))
            {
                sqlCommand.Parameters.AddWithValue("@Id", id);
                sqlCommand.ExecuteNonQuery();
            }
            return true;
        }

        List<Product> IProductRepo.GetAllProducts()
        {
            List<Product> products = new List<Product>();
            string sqlQuery = $"select * from [dbo].[Productos]";
            using (SqlCommand sqlCommand = new SqlCommand(sqlQuery, connection))
            {
                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();

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
                sqlDataReader.Close();

            }
            return products;
            

        }

        bool IProductRepo.UpdateProduct(int id, Product product)
        {
            if(!CheckIfProductExists(id))
            {
                throw new InvalidOperationException("Product doesn't exist");
            }
            string sqlQuery = @"update [dbo].[Productos] set Name=@Name, Gramaje=@Gramaje, Costo=@Costo, PrecioVenta=@PrecioVenta, IdProveedor=@IdProveedor where Id=@Id";
            using (SqlCommand sqlCommand = new SqlCommand( sqlQuery, connection))
            {
                sqlCommand.Parameters.AddWithValue("@Name", product.Name);
                sqlCommand.Parameters.AddWithValue("@Gramaje", product.Gramaje);
                sqlCommand.Parameters.AddWithValue("@Costo", product.Costo);
                sqlCommand.Parameters.AddWithValue("@PrecioVenta", product.PrecioVenta);
                sqlCommand.Parameters.AddWithValue("@IdProveedor", product.IdProvedor);
                sqlCommand.Parameters.AddWithValue("@Id", id);
                sqlCommand.ExecuteNonQuery();
            }
            return true;
        }             
       
    }
}
