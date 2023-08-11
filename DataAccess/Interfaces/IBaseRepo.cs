using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Interfaces
{
    public interface IBaseRepo
    {
        public bool UpdateInDataBase(string sqlQuery, List<SqlParameter> sqlParameters);
        public SqlDataReader GetFromDataBase(string sqlQuery);
        public bool UpdateInDataBase(string sqlQuery);
        public SqlDataReader GetFromDataBase(string sqlQuery, List<SqlParameter> sqlParameters);

    }
}
