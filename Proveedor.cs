namespace MercaExpress
{
    public class Proveedor
    {
        int idProveedor;
        string nombreProveedor;
        List<Producto> productosProveedor = new List<Producto>();

        public Proveedor(int idProveedor, string nombreProveedor, List<Producto> productos)
        {
            this.idProveedor = idProveedor;
            this.nombreProveedor = nombreProveedor;
            productosProveedor.AddRange(productos);
        }
    }
}
