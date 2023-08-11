using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Interfaces
{
    public interface IInventariosRepo
    {
        List <double> AgregarAInventarioBodega(List<int> listadoProductos, List <double> listadoCantidades);
        int GetInventarioBodegaById (int id);
        int GetInventarioExhibicionById(int id);
        List <int> AgregarAInventarioExhibicion (List<int> listadoProductos, List <int> listadoCantidades);
        List <double> SacarDeInvetarioBodega(List<ProductQuantity> productQuantity);
        List <int> SacarDeInventarioExhibicion(List<int> listadoProductos, List<int> listadoCantidades);
        

    }
}
