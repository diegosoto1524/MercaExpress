using System.Data.SqlClient;

namespace MercaExpress
  
{
    public class Metodos
    {
        
        public void AgregarAInventarioBodega (Producto producto, int agregar) => producto.CantidadEnBodega+= agregar;        
        public void AgregarAInventarioExhibicion(Producto producto, int agregar) => producto.CantidadEnExhibicion += agregar;
        public void QuitarDeInventarioBodega(Producto produto, int restar) => produto.CantidadEnBodega -= restar;
        public void QuitarDeInventarioExhibicion (Producto produto, int restar)=>produto.CantidadEnExhibicion -= restar;
        public void AgregarABodega (List<ProductoCantidad> lista)
        {
            foreach (var p in lista)
            {
                for (int j = 0;j<Producto.ListadoProductos.Count; j++)
                {
                    if (p.Producto == Producto.ListadoProductos[j])
                    {
                        AgregarAInventarioBodega(Producto.ListadoProductos[j], p.Cantidad);   
                    }
                }
            }
        }
        public void SacarDeBodega (List<ProductoCantidad> lista)
        {
            foreach (var p in lista)
            {
                for (int j = 0; j < Producto.ListadoProductos.Count; j++)
                {
                    if (p.Producto == Producto.ListadoProductos[j])
                    {
                        QuitarDeInventarioBodega(Producto.ListadoProductos[j], p.Cantidad);
                    }
                }
            }
        }
        public void AgregarAExhibicion (List<ProductoCantidad> lista)
        {
            foreach (var p in lista)
            {
                for (int j = 0; j < Producto.ListadoProductos.Count; j++)
                {
                    if (p.Producto == Producto.ListadoProductos[j])
                    {
                        AgregarAInventarioExhibicion(Producto.ListadoProductos[j], p.Cantidad);
                    }
                }
            }

        }
        public void SacarDeExhibicion (List<ProductoCantidad> lista)
        {
            foreach (var p in lista)
            {
                for (int j = 0; j < Producto.ListadoProductos.Count; j++)
                {
                    if (p.Producto == Producto.ListadoProductos[j])
                    {
                        QuitarDeInventarioExhibicion(Producto.ListadoProductos[j], p.Cantidad);
                    }
                }
            }

        }        
        public Producto buscarProductoPorId(int idBuscado)
        {
            Producto producto = null;
            for(int i = 0; i < Producto.ListadoProductos.Count; i++)
            {
                if (idBuscado == Producto.ListadoProductos[i].Id)
                {
                    producto = Producto.ListadoProductos[i];
                    break;
                }                    
            }
            return producto;
        }
       
    }
}
