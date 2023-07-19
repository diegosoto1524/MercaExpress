using System.Reflection.Metadata.Ecma335;
using System.Collections.Generic;
using System;

namespace Entities
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Gramaje { get; set; }       
        public double Costo { get; set; }
        public double PrecioVenta { get; set; }
        public UnidadDeMedida UnidadDeMedida { get; set; }
        public ProductFamily ProductFamilies { get; set; }   
        public int IdProvedor { get; set; }
        public int CantidadEnBodega { get; set; }
        public int CantidadEnExhibicion { get; set; }        
        
                  
        public Product()
        {       
            // Constructor sin parámetros requerido para la deserialización
        }

    }
}
