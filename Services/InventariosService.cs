using MercaExpress;
using DataAcces;
using DataAccess.Interfaces;
using Entities;
using MercaExpress.Services;
using DataAccess;

namespace MercaExpress.Services
{
    public class InventariosService : IInventariosService
    {
        IInventariosRepo repo;
        string conectionString = "Server=HOWARD\\SQLEXPRESS;Database=MercaExpressDB;User Id=db; Password=123456789;Encrypt=true;TrustServerCertificate=true";
        public InventariosService()
        {
            repo = new InventariosRepo(conectionString);
        }

        public List<int> AgregarAInventarioBodega(List<Product> listadoProductos, List<int> listadoCantidades)
        {
            List<int> inventariosNuevos = repo.AgregarInventarioBodega(listadoProductos, listadoCantidades);
            return inventariosNuevos;
        }
    }
}
