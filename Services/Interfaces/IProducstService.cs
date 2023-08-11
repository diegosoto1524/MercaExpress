using Entities;
using MercaExpress;

namespace MercaExpress.Services;

public interface IProductsService
{
    bool UpdateProduct(int id, Product modificacionProducto);

    bool DeleteProduct(int id);

    Product CreateProduct(Product productoNuevo);

    Product GetProductById(int id);

    List<Product> GetAllProducts();

    List<Product> GetProductsByProviderId(int id);
}