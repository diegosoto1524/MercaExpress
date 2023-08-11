using DataAccess.Interfaces;
using Entities;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class SuplierRepo : ISuplierRepo
    {
        IBaseRepo baseRepo;

        public SuplierRepo(IBaseRepo baseRepo)
        {
            this.baseRepo = baseRepo;
        }
        public bool CreateSuplier(Suplier suplier)
        {
            int id = GetLastId() + 1;
            string sqlQuery = "insert into [dbo].[Supliers] (Id,Name,Phone,Email,CreationDate) values (@Id,@Name, @Phone, @Email, @CreationDate)";
            List <SqlParameter> sqlParameters = new List <SqlParameter> ();
            sqlParameters.Add(new SqlParameter("@Id", id));
            sqlParameters.Add(new SqlParameter("@Name", suplier.Name));
            sqlParameters.Add(new SqlParameter("@Phone", suplier.Phone));
            sqlParameters.Add(new SqlParameter("@Email",suplier.Email));
            sqlParameters.Add(new SqlParameter("@CreationDate",DateTime.Now));
            baseRepo.UpdateInDataBase(sqlQuery,sqlParameters);

            return true;
        }

        private int GetLastId()
        {
            int lastId = 0;
            string sqlQuery = "select max (Id) from [dbo].[Supliers]";
            using (SqlDataReader sqlDataReader = baseRepo.GetFromDataBase(sqlQuery))
            {
                if (sqlDataReader.Read())
                {
                    var result = sqlDataReader.GetValue(0);
                    if (result != null && result != DBNull.Value)
                    {
                        lastId = (int)result;
                    }
                }
                return lastId;
            }
        }

        public bool DeleteSuplier(Suplier suplier)
        {
            if (GetSuplierById (suplier.Id)==null) 
            {
                throw new InvalidOperationException($"Suplier With Id {suplier.Id} already exists, please check");
            }
            string sqlQuery = $"delete from [dbo].[Supliers] where Id = {suplier.Id}";
            return baseRepo.UpdateInDataBase(sqlQuery);
        }

        public Suplier GetSuplierById(int id)
        {
            string sqlQuery = $"SELECT * FROM [dbo].[Supliers] where Id={id}";
            Suplier suplier = null;
            using (SqlDataReader sqlDataReader = baseRepo.GetFromDataBase(sqlQuery))
            {
                if (sqlDataReader.Read())
                {
                    suplier = new Suplier
                    {
                        Id = id,
                        Name = sqlDataReader["Name"].ToString(),
                        Phone = sqlDataReader["Phone"].ToString(),
                        Email = sqlDataReader["Email"].ToString(),
                        CreationDate = (DateTime)sqlDataReader["CreationDate"]
                    };
                }
                return suplier;
            }
        }

        public List<Suplier> GetSupliers()
        {
            List <Suplier> supliers = new List<Suplier>();
            string sqlQuery = "select * from [dbo].[Supliers]";
            SqlDataReader sqlDataReader=baseRepo.GetFromDataBase (sqlQuery);
            while (sqlDataReader.Read())
            {
                supliers.Add(new Suplier
                {
                    Id = (int)sqlDataReader["Id"],
                    Name = sqlDataReader["Name"].ToString(),
                    Phone = sqlDataReader["Phone"].ToString(),
                    Email = sqlDataReader["Email"].ToString(),
                    CreationDate = (DateTime)sqlDataReader["CreationDate"]
                });
            }
            return supliers;
        }

        public bool ModifySuplier(Suplier suplier)
        {
            string sqlQuery="Update from [dbo].[Supliers] set Phone=@Phone, Email=@Email, Name=@Name, CreationDate=@CreationDate where Id=@Id";
            List<SqlParameter> sqlParameters = new List<SqlParameter>();
            sqlParameters.Add(new SqlParameter("@Name",suplier.Name));
            sqlParameters.Add(new SqlParameter("@Email", suplier.Email));
            sqlParameters.Add(new SqlParameter("@Phone",suplier.Phone));
            sqlParameters.Add(new SqlParameter("@CreationDate",suplier.CreationDate));
            return baseRepo.UpdateInDataBase (sqlQuery, sqlParameters); 
        }
        
    }
}
