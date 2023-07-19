using Entities;
using MercaExpress;

namespace MercaExpress.Services;

public interface IInventariosService
{
    public List<int> AgregarAInventarioBodega(List<Product> listadoProductos, List<int> listadoCantidades);
}
