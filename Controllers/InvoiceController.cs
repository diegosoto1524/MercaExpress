using Entities;
using MercaExpress.Services;
using Microsoft.AspNetCore.Mvc;

namespace MercaExpress.Controllers
{
    [ApiController]
    [Route ("controller")]
    public class InvoiceController:ControllerBase
    {
        private readonly ILogger<InvoiceController> _logger;
        private readonly IInvoiceService _invoiceService;

        public InvoiceController (ILogger<InvoiceController> logger, IInvoiceService invoiceService)
        {
            _logger = logger;
            _invoiceService = invoiceService;
        }

        [HttpPost]
        public ActionResult CreateInvoice (int idClient,List<ProductQuantity> productQuantities)
        {
            double price = _invoiceService.CreateInvoice(idClient, productQuantities);
            return Ok(price);
        }
        [HttpGet]
        public ActionResult GetAllInvoices () 
        { 
            return Ok(_invoiceService.GetAllInvoices());
        }
        [HttpGet ("id")]
        public ActionResult GetInvoiceById (int id)
        { 
            return Ok(_invoiceService.GetInvoiceById(id));
        }
    }
}
