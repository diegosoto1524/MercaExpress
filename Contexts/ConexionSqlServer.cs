using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace MercaExpress.Contexts
{
    public class ConexionSqlServer:DbContext
    {

        public ConexionSqlServer(DbContextOptions<ConexionSqlServer> options) : base(options)
        {
            //
        }

            public DbSet<Products> Products { get; set; }
              
    }
}
 