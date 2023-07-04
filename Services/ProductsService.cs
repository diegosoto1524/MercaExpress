using MercaExpress;

namespace MercaExpress.Services;

public class ProductsService : IProductsService
{
    public ProductsService()
    {
    }

    public Producto CreateProduct(Producto productoNuevo)
    {
        throw new NotImplementedException();
    }

    public Producto DeleteProduct(int id)
    {
        throw new NotImplementedException();
    }

    public List<Producto> GetAllProducts()
    {
        throw new NotImplementedException();
    }

    public Producto GetProductById(int id)
    {
        throw new NotImplementedException();
    }

    public List<Producto> GetProductsByProviderId(int id)
    {
        throw new NotImplementedException();
    }

    public Producto UpdateProduct(int id, Producto modificacionProducto)
    {
        var productoExistente = Producto.ListadoProductos.FirstOrDefault(p => p.Id == modificacionProducto.Id);

        if (productoExistente == null) { return null; }

        productoExistente.NombreProducto = modificacionProducto.NombreProducto;
        productoExistente.IdProvedorProducto = modificacionProducto.IdProvedorProducto;
        productoExistente.PrecioVenta = modificacionProducto.PrecioVenta;
        productoExistente.Gramaje = modificacionProducto.Gramaje;
        productoExistente.Costo = modificacionProducto.Costo;

        return productoExistente;
    }
}