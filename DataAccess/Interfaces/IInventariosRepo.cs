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
        List <int> AgregarInventarioBodega(List<Product> listadoProductos, List <int> listadoCantidades);
        bool AgregarInventarioExhibicion (List<Product> listadoProductos, List <int> listadoCantidades);
        bool SacarDeInvetarioBodega(List<Product> listadoProductos, List<int> listadoCantidades);
        bool SacarDeInventarioExhibicion(List<Product> listadoProductos, List<int> listadoCantidades);

    }
}
