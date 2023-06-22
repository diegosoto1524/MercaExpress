using System.Reflection.Metadata.Ecma335;
using System.Collections.Generic;
using System;

namespace MercaExpress
{
    public class Producto
    {
        public int Id { get;}
        public string NombreProducto { get; set; }
        public int Gramaje { get; set; }       
        public double Costo { get; set; }
        public double PrecioVenta { get; set; }
        public int IdProvedorProducto { get; set; }
        public int CantidadEnBodega { get; set; }
        public int CantidadEnExhibicion { get; set; }        
        private static int consecutivoId=1;
        public static List<Producto> ListadoProductos = new List<Producto>();

        
        //public Producto(string nombreProducto, int gramaje, double costo, double precio, int idProveedor)
        //{
        //    if (ListadoProductos.Select(x => x.NombreProducto).Contains(nombreProducto))
        //    {
        //        throw new Exception("nombre ya existe");
        //    }
        //    else
        //    {
        //        this.Id = consecutivoId;
        //        this.NombreProducto = nombreProducto;
        //        this.Gramaje = gramaje;
        //        this.Costo = costo;
        //        this.PrecioVenta = precio;
        //        this.IdProvedorProducto = idProveedor;
        //        consecutivoId++;
        //        ListadoProductos.Add(this);
        //    }

        //}       
        public Producto()
        {
            Id = consecutivoId++;            
            // Constructor sin parámetros requerido para la deserialización
        }

    }
}
