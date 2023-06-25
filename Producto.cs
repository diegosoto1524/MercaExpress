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
          
        public Producto()
        {
            Id = consecutivoId++;            
            // Constructor sin parámetros requerido para la deserialización
        }

    }
}
