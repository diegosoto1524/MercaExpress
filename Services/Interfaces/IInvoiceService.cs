using Entities;

namespace MercaExpress.Services
{
    public interface IInvoiceService
    {
        double CreateInvoice(int idClient, List<ProductQuantity>productQuantities);
        public List<Invoice> GetAllInvoices();
        public Invoice GetInvoiceById(int id);


    }
}
