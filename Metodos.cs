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
                for (int j = 0;j<Producto.listadoProductos.Count; j++)
                {
                    if (p.Producto == Producto.listadoProductos[j])
                    {
                        AgregarAInventarioBodega(Producto.listadoProductos[j], p.Cantidad);   
                    }
                }
            }
        }
        public void SacarDeBodega (List<ProductoCantidad> lista)
        {
            foreach (var p in lista)
            {
                for (int j = 0; j < Producto.listadoProductos.Count; j++)
                {
                    if (p.Producto == Producto.listadoProductos[j])
                    {
                        QuitarDeInventarioBodega(Producto.listadoProductos[j], p.Cantidad);
                    }
                }
            }
        }
        public void AgregarAExhibicion (List<ProductoCantidad> lista)
        {
            foreach (var p in lista)
            {
                for (int j = 0; j < Producto.listadoProductos.Count; j++)
                {
                    if (p.Producto == Producto.listadoProductos[j])
                    {
                        AgregarAInventarioExhibicion(Producto.listadoProductos[j], p.Cantidad);
                    }
                }
            }

        }
        public void SacarDeExhibicion (List<ProductoCantidad> lista)
        {
            foreach (var p in lista)
            {
                for (int j = 0; j < Producto.listadoProductos.Count; j++)
                {
                    if (p.Producto == Producto.listadoProductos[j])
                    {
                        QuitarDeInventarioExhibicion(Producto.listadoProductos[j], p.Cantidad);
                    }
                }
            }

        }        
        public Producto buscarProductoPorId(int idBuscado)
        {
            Producto producto = null;
            for(int i = 0; i < Producto.listadoProductos.Count; i++)
            {
                if (idBuscado == Producto.listadoProductos[i].Id)
                {
                    producto = Producto.listadoProductos[i];
                    break;
                }                    
            }
            return producto;
        }
        /*public Producto buscarProductoPorNombre (string nombreBuscado)
        {
            metodo para buscar parciales de un nombre
        }*/

        public Producto buscarpornombre()
        {
            return new Producto("diego",0.1);
        }
    }
}
