using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class InvoiceProduct
    {
        public int Id { get; set; }
        public Invoice Invoice { get; set; }
        public Product Product { get; set; }
        public int Quantity { get; set; }
    }
}
