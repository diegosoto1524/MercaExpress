namespace Entities
{
    public class Pedido
    {
        int numeroPedido;
        DateTime fechaPedido;
        DateTime fechaRecepcion;
        int idProveedor;
        string numeroFacturaProveedor;
        List<ProductQuantity> listadoPedido = new List<ProductQuantity>();

        public static List<Pedido> historicoPedidos = new List<Pedido>();

       

        public void AgregarPedidoaHistorico(Pedido entrada)
        {
            historicoPedidos.Add(entrada); 
        }
    }
}
