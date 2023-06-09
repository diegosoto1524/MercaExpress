using System.Reflection.Metadata.Ecma335;

namespace MercaExpress
{
    public class Producto
    {
        public int Id { get; }  
        int gramaje;
        string nombreProducto;
        double costo;
        double precioVenta;
        Proveedor provedorProducto;
        public int CantidadEnBodega { get; set; }
        public int CantidadEnExhibicion { get; set; }        
        static int consecutivoId;
        public static List<Producto> listadoProductos = new List<Producto>();
        public void AgregarProductoAListado(Producto producto)
        {
            listadoProductos.Add(producto);
        }
        public Producto(string nombre, double costo)
        {
            if (listadoProductos.Select(x => x.nombreProducto).Contains(nombre))
            {
                throw new Exception("nombre ya existe");
            }
            else
            {
                this.Id = consecutivoId;
                this.nombreProducto = nombre;
                this.costo = costo;
                //this.precioVenta = precioVenta;
                //this.provedorProducto = provedorProducto;
                consecutivoId++;
            }
        }              
                      
    }
}
