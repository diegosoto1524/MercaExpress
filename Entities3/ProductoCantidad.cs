
namespace Entities
{
    public struct ProductoCantidad
    {
        public Product Producto { get; init; }
        public int Cantidad { get; set; }
        

        public ProductoCantidad (Product producto, int cantidad)
        {
            this.Producto = producto;
            this.Cantidad = cantidad;
        }

       
        
    }
}   
