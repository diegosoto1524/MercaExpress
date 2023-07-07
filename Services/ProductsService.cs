using MercaExpress;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Net;

namespace MercaExpress.Services;

public class ProductsService : IProductsService
{
    public ProductsService()
    {
    }

    public Producto CreateProduct(Producto productoNuevo)
    {
        bool nombreExistente = Producto.ListadoProductos.Any(p => p.NombreProducto == productoNuevo.NombreProducto && p.Gramaje == productoNuevo.Gramaje);
        if (nombreExistente)
        {
            throw new Exception("El producto ya existe");            
        }
        Producto.ListadoProductos.Add(productoNuevo);
        return productoNuevo;
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