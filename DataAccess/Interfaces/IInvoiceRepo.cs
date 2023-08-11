using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Interfaces
{
    public interface IInvoiceRepo
    {
        void CreateInvoice(int idClient, List<ProductQuantity> productQuantity);
        public Invoice GetInvoiceById(int id);
        public List<Invoice> GetAllInvoices();

    }
}
