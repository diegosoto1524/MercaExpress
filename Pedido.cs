namespace MercaExpress
{
    public class Pedido
    {
        int numeroPedido;
        // DateTime fechaPedido;
        // DateTime fechaRecepcion;
        // Proveedor proveedor;
        string numeroFacturaProveedor;
        List<ProductoCantidad> listadoPedido = new List<ProductoCantidad>();

        public static List<Pedido> historicoPedidos = new List<Pedido>();

        public Pedido(int numeroPedido, List<ProductoCantidad> listadoPedido)
        {
            this.listadoPedido = listadoPedido;
            this.numeroPedido = numeroPedido;
            this.numeroFacturaProveedor = "pdte";
        }

        public void AgregarPedidoaHistorico(Pedido entrada)
        {
            historicoPedidos.Add(entrada); 
        }
    }
}
