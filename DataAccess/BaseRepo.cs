using DataAccess.Interfaces;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class BaseRepo:IBaseRepo
    {
        // dos métodos para modificar y para leer
        // buscar pruebas unitarias
        // inyección de dependencias
        // autenticación y seguridad en endpoints
        
        private readonly SqlConnection connection;
        public BaseRepo(string connectionString)
        {
            this.connection = new SqlConnection(connectionString);
            connection.Open();
        }

        public bool UpdateInDataBase (string sqlQuery, List<SqlParameter> sqlParameters)
        {
            using (SqlCommand sqlCommand = new SqlCommand(sqlQuery, connection))
            {
                foreach (SqlParameter p in sqlParameters)
                {
                    sqlCommand.Parameters.Add(p);
                }
                sqlCommand.ExecuteNonQuery();
            }
            return true;
        }
        public bool UpdateInDataBase(string sqlQuery)
        {
            using (SqlCommand sqlCommand = new SqlCommand(sqlQuery, connection))
            {
               sqlCommand.ExecuteNonQuery();
            }
            return true;
        }
        public SqlDataReader GetFromDataBase (string sqlQuery)
        {   
            using (SqlCommand sqlCommand = new SqlCommand(sqlQuery, connection))
            {
                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
             
                return sqlDataReader;                
            }
        }
        public SqlDataReader GetFromDataBase(string sqlQuery, List<SqlParameter> sqlParameters)
        {
            using (SqlCommand sqlCommand = new SqlCommand(sqlQuery, connection))
            {
                foreach(SqlParameter p in sqlParameters)
                {
                    sqlCommand.Parameters.Add(p);
                }
                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();

                return sqlDataReader;
            }
        }
    }
}
