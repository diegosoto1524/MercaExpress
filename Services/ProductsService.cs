using MercaExpress;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Net;
using DataAcces;
using Entities;
using DataAccess.Interfaces;

namespace MercaExpress.Services;

public class ProductsService : IProductsService
{
    IProductRepo repo;
    string conectionString = "Server=HOWARD\\SQLEXPRESS;Database=MercaExpressDB;User Id=db; Password=123456789;Encrypt=true;TrustServerCertificate=true";
    public ProductsService()
    {
        repo = new ProductRepo(conectionString);
    }

    public Product CreateProduct(Product productoNuevo)
    {
        if (repo.CreateProduct(productoNuevo))
        {
            return productoNuevo;
        }

        return null;        
    }
       
    public List<Product> GetAllProducts()
    {
        return repo.GetAllProducts();
    }

    public Product GetProductById(int id)
    {
        Product producto=repo.GetProductById(id);
        return producto;
    }

    public List<Product> GetProductsByProviderId(int id)
    {
        throw new NotImplementedException();
    }

    public bool UpdateProduct(int id, Product modificacionProducto)
    {
        
        return repo.UpdateProduct(id, modificacionProducto);
    }

    bool IProductsService.DeleteProduct(int id)
    {
        bool eliminado = repo.DeleteProduct(id);
        return eliminado;
    }
}