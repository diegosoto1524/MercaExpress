using MercaExpress.Services;
using Microsoft.AspNetCore.Mvc;

namespace MercaExpress.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly ILogger<ProductsController> _logger;
        private readonly IProductsService _productsService;
        
        public ProductsController(ILogger<ProductsController> logger,
        IProductsService productsService)
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
            try
            {
                Producto productoCreado = _productsService.CreateProduct(productoNuevo);
                return CreatedAtAction(nameof(CrearProducto), new { id = productoCreado.Id }, productoCreado);
            }
            catch (Exception ex)
            {
                return Conflict(ex.Message);
            }
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