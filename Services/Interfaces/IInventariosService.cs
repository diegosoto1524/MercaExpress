using Entities;
using MercaExpress;

namespace MercaExpress.Services;

public interface IInventariosService
{
    public List<double> AgregarAInventarioBodega(List<int> listadoProductos, List<double> listadoCantidades);
    public int GetInventarioBodegaById(int id);
    public int GetInventarioExhibicionById(int id);
    public List<int> AgregarAInventarioExhibicion(List<int> listadoProductos, List<int> listadoCantidades);
    public List<double> SacarDeInventarioBodega(List<ProductQuantity> productQuantity);
    public List<int> SacarDeInventarioExhibicion(List<int> listadoProductos, List<int> listadoCantidades);

}
