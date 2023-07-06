using MercaExpress.Services;
using Microsoft.AspNetCore.Mvc;

namespace MercaExpress.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly ILogger<ProductsController> _logger;
        private readonly ProductsService _productsService;

        public ProductsController(ILogger<ProductsController> logger,
        ProductsService productsService)
        {
            _logger = logger;
            _productsService = productsService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Producto>> ObtenerTodosLosProductos()
        {
            return Ok(Producto.ListadoProductos);
        }

        [HttpGet("{id}")]
        public ActionResult<Producto> ObtenerProductoPorId(int id)
        {
            Producto producto = Producto.ListadoProductos.FirstOrDefault(p => p.Id == id);
            if (producto == null)
            {
                return NotFound();
            }
            return Ok(producto);
        }

        [HttpPost]
        public ActionResult CrearProducto([FromBody] Producto productoNuevo)
        {
            bool nombreExistente = Producto.ListadoProductos.Any(p => p.NombreProducto == productoNuevo.NombreProducto && p.Gramaje == productoNuevo.Gramaje);
            if (nombreExistente)
            {
                return Conflict("el producto ya existe");
            }
            Producto.ListadoProductos.Add(productoNuevo);
            return CreatedAtAction(nameof(CrearProducto), new { id = productoNuevo.Id }, productoNuevo);

        }

        [HttpPut("{id}")]
        public ActionResult Put(int id, Producto modificacionProducto)
        {
            var result = _productsService.UpdateProduct(id, modificacionProducto);
            return result == null ? NotFound() : Ok(result);
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            Producto aBorrar = Producto.ListadoProductos.FirstOrDefault(p => p.Id == id);
            if (aBorrar == null)
            {
                return NotFound();
            }
            Producto.ListadoProductos.Remove(aBorrar);
            return NoContent();

        }
    }
}