using DataAccess.Interfaces;
using Entities;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class ClientRepo : IClientRepo
    {
        IBaseRepo baseRepo;
        public ClientRepo(IBaseRepo baseRepo)
        {
            this.baseRepo = baseRepo;
        }
        public bool CreateClient(Client client)
        {
            if (GetClientById(client.Id) != null)
            {
                throw new InvalidOperationException("Client Already Exist, Pease Check");
            }
            string sqlQuery = @"INSERT INTO [dbo].[Clients] (Id,Name,Birthday, Address, Email, Phone)VALUES(@Id,@Name, @Birthday, @Address, @Email, @Phone)";
           
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@Id", client.Id));
            parameters.Add(new SqlParameter("@Name", client.Name));
            parameters.Add(new SqlParameter("@Birthday", client.Birthday));
            parameters.Add(new SqlParameter("@Address", client.Address));
            parameters.Add(new SqlParameter("@Email", client.Email));
            parameters.Add(new SqlParameter("@Phone", client.Phone));
            
            baseRepo.UpdateInDataBase(sqlQuery, parameters);
            return true;
        }
            
        public bool DeleteClient(int id)
        {
            if (GetClientById(id) != null)
            {
                string sqlQuery = $"delete from [dbo].[Clients] where id={id}";                
                return baseRepo.UpdateInDataBase(sqlQuery);
            }
            else
            {
                throw new InvalidOperationException($"client with Id: {id} does not exist");
            }
        }

        public List<Client> GetAllClients()
        {
            List<Client> clients = new List<Client>();
            string sqlQuery = "select * from [dbo].[Clients]";
            using (SqlDataReader sqlDataReader = baseRepo.GetFromDataBase(sqlQuery))
            {

                while (sqlDataReader.Read())
                {
                    Client client = new Client
                    {
                        Id = int.Parse(sqlDataReader["Id"].ToString()),
                        Name = sqlDataReader["Name"].ToString(),
                        Birthday = DateTime.Parse(sqlDataReader["Birthday"].ToString()),
                        Address = sqlDataReader["Address"].ToString(),
                        Email = sqlDataReader["Email"].ToString(),
                        Phone = sqlDataReader["Phone"].ToString()
                    };
                    clients.Add(client);
                }
            }
            
            return clients;
        }
        public Client GetClientById(int id)
        {
            Client client = null;
            string sqlQuery = $"select * from [dbo].[Clients] where Id={id}";
            using (SqlDataReader sqlDataReader = baseRepo.GetFromDataBase(sqlQuery))
            {
                while (sqlDataReader.Read())
                {
                    client = new Client
                    {
                        Id = int.Parse(sqlDataReader["Id"].ToString()),
                        Name = sqlDataReader["Name"].ToString(),
                        Birthday = DateTime.Parse(sqlDataReader["Birthday"].ToString()),
                        Address = sqlDataReader["Address"].ToString(),
                        Email = sqlDataReader["Email"].ToString(),
                        Phone = sqlDataReader["Phone"].ToString()
                    };
                }
            }
            return client;

        }

        public bool ModifyCLient(int id, Client client)
        {
            List<SqlParameter> sqlParameters = new List<SqlParameter>();
            if (GetClientById(id) != null)
            {
                string sqlQuery = "UPDATE [dbo].[Clients] SET Id = @Id, Name = @Name, Birthday = @Birthday, Address = @Address, Email = @Email, Phone = @Phone WHERE Id = @Id";

                sqlParameters.Add(new SqlParameter("@Id", id));
                sqlParameters.Add(new SqlParameter("@Name", client.Name));
                sqlParameters.Add(new SqlParameter("@Birthday", client.Birthday));
                sqlParameters.Add(new SqlParameter("@Address", client.Address));
                sqlParameters.Add(new SqlParameter("@Email", client.Email));
                sqlParameters.Add(new SqlParameter("@Phone", client.Phone));
                
                return baseRepo.UpdateInDataBase(sqlQuery,sqlParameters);
            }
            else
            {
                throw new InvalidOperationException($"Client with id {id} does not exist");
            }
        }
    }
}
