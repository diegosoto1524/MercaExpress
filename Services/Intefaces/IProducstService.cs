using MercaExpress;

namespace MercaExpress.Services;

public interface IProductsService
{
    Producto UpdateProduct(int id, Producto modificacionProducto);

    Producto DeleteProduct(int id);

    Producto CreateProduct(Producto productoNuevo);

    Producto GetProductById(int id);

    List<Producto> GetAllProducts();

    List<Producto> GetProductsByProviderId(int id);
}