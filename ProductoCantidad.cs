namespace MercaExpress
{
    public struct ProductoCantidad
    {
        public Producto Producto { get; init; }
        public int Cantidad { get; set; }
        

        public ProductoCantidad (Producto producto, int cantidad)
        {
            this.Producto = producto;
            this.Cantidad = cantidad;
        }

       
        
    }
}   
