using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Interfaces;
using Entities;
using Microsoft.Data.SqlClient;

namespace DataAccess
{
    public class InvoiceRepo : IInvoiceRepo
    {
        IBaseRepo baseRepo;
        public InvoiceRepo(IBaseRepo baseRepo)
        {
            this.baseRepo = baseRepo;
        }
        public void CreateInvoice(int idClient, List<ProductQuantity> productQuantity)
        {
            CreateRegisterInTableInvoice(idClient);
            CreateRegisterInTableInvoiceProduct(productQuantity);   
        }

        private void CreateRegisterInTableInvoiceProduct(List<ProductQuantity> productQuantity)
        {
            int id = GetLastIdInvoiceProduct();
            string sqlquery = "insert into [dbo].[InvoiceProduct] (Id, IdInvoice,IdProduct, Quantity) values (@Id, @IdInvoice,@IdProduct, @Quantity)";
            int idInvoice = GetLastIdInvoice();
            for (int i = 0; i < productQuantity.Count; i++)
            {
                id ++;
                int idProduct = productQuantity[i].Product.Id;
                double quant = productQuantity[i].Quantity;
                List<SqlParameter> sqlParameters = new List<SqlParameter>();
                sqlParameters.Add(new SqlParameter("@Id", id));
                sqlParameters.Add(new SqlParameter("@IdProduct", idProduct));
                sqlParameters.Add(new SqlParameter("@Quantity", quant));
                sqlParameters.Add(new SqlParameter("@IdInvoice", idInvoice));
                baseRepo.UpdateInDataBase(sqlquery, sqlParameters);
            }

        }

        private void CreateRegisterInTableInvoice(int idClient)
        {
            int id = GetLastIdInvoice() + 1;
            List<SqlParameter> sqlParameters = new List<SqlParameter>();
            string sqlQuery = "insert into [dbo].[Invoices] (Id, IdClient, Date) values (@Id, @IdCLient, @Date)";
            sqlParameters.Add(new SqlParameter("@Id", id));
            sqlParameters.Add(new SqlParameter("@IdCLient", idClient));
            sqlParameters.Add(new SqlParameter("@Date", DateTime.Today));
            baseRepo.UpdateInDataBase(sqlQuery, sqlParameters);      
        }

        private int GetLastIdInvoiceProduct()
        {
            int lastId = 0;
            string sqlQuery = "select MAX (Id) from [dbo].[InvoiceProduct]";
            using (SqlDataReader sqlDataReader = baseRepo.GetFromDataBase(sqlQuery))
            {
                if (sqlDataReader.Read())
                {
                    var result= sqlDataReader.GetValue(0);
                    if(result != null && result!=DBNull.Value)
                    {
                        lastId=Convert.ToInt32(result);
                    }
                }
            }
            return lastId;
        }

        public List<Invoice> GetAllInvoices()
        {
            List <Invoice> invoicesList = new List<Invoice>();
            string sqlQuery = "select * from [dbo].[Invoices]";
            SqlDataReader sqlDataReader=baseRepo.GetFromDataBase(sqlQuery);

            while (sqlDataReader.Read())
            {
                invoicesList.Add(new Invoice
                {
                    Id = int.Parse(sqlDataReader["Id"].ToString()),
                    IdClient = int.Parse(sqlDataReader["IdClient"].ToString()),
                    Date = (DateTime)sqlDataReader["Date"]                    
                }
                );
            }
            return invoicesList;
        }            

        private int GetLastIdInvoice()
        {
            int lastId = 0;
            string sqlQuery = "SELECT MAX(Id) FROM [dbo].[Invoices]";
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
            }
            return lastId;
        }

        public Invoice GetInvoiceById(int id)
        {
            Invoice invoice = null;
            string sqlQuery = $"select * from [dbo].[Invoices] where id = {id}";
            SqlDataReader sqlDataReader = baseRepo.GetFromDataBase(sqlQuery);
            if (sqlDataReader.Read())
            {
                invoice = new Invoice
                {
                    Id = id,
                    IdClient = (int)sqlDataReader["IdClient"],
                    Date = (DateTime)sqlDataReader["Date"]
                };
            }
            return invoice;
        }
    }
}
