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
        
        public InventariosService(IInventariosRepo repo)
        {
            this.repo = repo;
        }

        public List<double> AgregarAInventarioBodega(List<int> listadoProductos, List<double> listadoCantidades)
        {
            List<double> inventariosNuevos = repo.AgregarAInventarioBodega(listadoProductos, listadoCantidades);
            return inventariosNuevos;
        }
              

        public List<int> AgregarAInventarioExhibicion(List<int> listadoProductos, List<int> listadoCantidades)
        {
            return repo.AgregarAInventarioExhibicion(listadoProductos,listadoCantidades);
        }

        public int GetInventarioBodegaById(int id)
        {
            return repo.GetInventarioBodegaById(id);
        }
            

        public int GetInventarioExhibicionById(int id)
        {
           return repo.GetInventarioExhibicionById(id);
        }

        public List<double> SacarDeInventarioBodega(List<ProductQuantity> productQuantity)
        {
            return repo.SacarDeInvetarioBodega(productQuantity);
        }

        public List<int> SacarDeInventarioExhibicion(List<int> listadoProductos, List<int> listadoCantidades)
        {
            return repo.SacarDeInventarioExhibicion(listadoProductos, listadoCantidades);
        }
                
    }
}
