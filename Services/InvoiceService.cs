using MercaExpress.Services;
using MercaExpress;
using DataAccess.Interfaces;
using DataAccess;
using Entities;
using Microsoft.Data.SqlClient;
using DataAcces;

namespace MercaExpress.Services
{
    public class InvoiceService:IInvoiceService
    {
        IInvoiceRepo invoiceRepo;
        IInventariosRepo inventariosRepo;
        IProductRepo productRepo;
        
        public InvoiceService(IInvoiceRepo invoiceRepo, IInventariosRepo inventariosRepo, IProductRepo productRepo)
        {
            this.invoiceRepo = invoiceRepo;
            this.productRepo = productRepo;
            this.inventariosRepo = inventariosRepo; 
        }

       public double CreateInvoice(int idClient, List<ProductQuantity> productQuantities)
        {
            invoiceRepo.CreateInvoice(idClient, productQuantities);

            double invoicePrice = 0;
            for (int i = 0; i < productQuantities.Count; i++)
            {
                double productSellingPrice = productRepo.GetProductPrice(productQuantities[i].Product.Id);
                invoicePrice += productSellingPrice * productQuantities[i].Quantity;

            }
            //invoicePrice = products.Zip(quantities, (producto, cantidad) => producto.PrecioVenta * cantidad).Sum();

            inventariosRepo.SacarDeInvetarioBodega(productQuantities);

            return invoicePrice;
        }
        public List<Invoice> GetAllInvoices()
        {
            return invoiceRepo.GetAllInvoices();
        }
        public Invoice GetInvoiceById(int id)
        {
            return invoiceRepo.GetInvoiceById(id);
        }



    }
}
