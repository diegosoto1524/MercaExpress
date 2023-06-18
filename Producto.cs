using System.Reflection.Metadata.Ecma335;

namespace MercaExpress
{
    public class Producto
    {
        public int Id { get; }
        string NombreProducto { get; set; }
        int Gramaje { get; set; }       
        double Costo { get; set; }
        double PrecioVenta { get; set; }
        int IdProvedorProducto { get; set; }
        public int CantidadEnBodega { get; set; }
        public int CantidadEnExhibicion { get; set; }        
        static int consecutivoId;
        public static List<Producto> ListadoProductos = new List<Producto>();
       
        public Producto(string nombreProducto, int gramaje, double costo, double precio, int idProveedor)
        {
            if (ListadoProductos.Select(x => x.NombreProducto).Contains(nombreProducto))
            {
                throw new Exception("nombre ya existe");
            }
            else
            {
                this.Id = consecutivoId;
                this.NombreProducto = nombreProducto;
                this.Gramaje = gramaje;
                this.Costo = costo;
                this.PrecioVenta = precio;
                this.IdProvedorProducto = idProveedor;
                consecutivoId++;
                ListadoProductos.Add(this);
            }
            
        }              
                      
    }
}
