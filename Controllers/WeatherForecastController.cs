using Microsoft.AspNetCore.Mvc;


namespace MercaExpress.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductsController : ControllerBase
    {        
        private readonly ILogger<ProductsController> _logger;

        public ProductsController(ILogger<ProductsController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Producto>> ObtenerTodosLosProductos()
        {
            return Ok(Producto.ListadoProductos);
        }
        
        [HttpGet ("{id}")]
        public ActionResult<Producto> ObtenerProductoPorId(int id)
        {
            Producto producto = Producto.ListadoProductos.FirstOrDefault(p=>p.Id == id);
            if (producto == null)
            {
                return NotFound();
            }
            return Ok(producto);
        }

        [HttpPost]
        public ActionResult CrearProducto([FromBody] Producto productoNuevo)
        {
            bool nombreExistente = Producto.ListadoProductos.Any(p => p.NombreProducto == productoNuevo.NombreProducto && p.Gramaje==productoNuevo.Gramaje);
            if (nombreExistente)
            {
                return Conflict("el producto ya existe");
            }
            Producto.ListadoProductos.Add(productoNuevo);
            return CreatedAtAction(nameof(CrearProducto), new { id = productoNuevo.Id }, productoNuevo);

        }

        [HttpPut("{id}")]
        public string Put(int id, [FromBody] string value)
        {
            return $"Actualizamos el product: {value}";
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            Producto aBorrar=Producto.ListadoProductos.FirstOrDefault(p=> p.Id == id);
            if (aBorrar == null) 
            {
                return NotFound();
            }
            Producto.ListadoProductos.Remove(aBorrar);
            //return CreatedAtAction(nameof(Delete), new { id = id }, aBorrar);
            return NoContent();

        }
    }
}