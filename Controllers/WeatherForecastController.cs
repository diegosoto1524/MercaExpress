using Microsoft.AspNetCore.Mvc;

namespace MercaExpress.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductsController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

        private readonly ILogger<ProductsController> _logger;

        public ProductsController(ILogger<ProductsController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public string Get()
        {
            return "Obtenemos todos los products";
        }
    
        [HttpPost ("Crear Producto Nuevo")]
        public string Post(string nombreProducto, int gramaje, double costo, double precio, int idProveedor)
        {
            Producto nuevo = new Producto(nombreProducto,gramaje,costo,precio,idProveedor);            
            return $"Product created with Id: {nuevo.Id}";

        }

        [HttpPut("{id}")]
        public string Put(int id, [FromBody] string value)
        {
            return $"Actualizamos el product: {value}";
        }

        [HttpDelete("{id}")]
        public string Delete(int id)
        {
            return $"Eliminamos el product: {id}";
        }
    }
}