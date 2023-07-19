using Entities;
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
        public ActionResult<IEnumerable<Product>> ObtenerTodosLosProductos()
        {
            return Ok(_productsService.GetAllProducts());
        }

        [HttpGet("{id}")]
        public ActionResult<Product> ObtenerProductoPorId(int id)
        {
            var producto=_productsService.GetProductById(id);
            if (producto == null)
            {
                return NotFound();
            }
            return Ok(producto);
        }

        [HttpPost]
        public ActionResult CreateProduct([FromBody] Product productoNuevo)
        {
            try
            {
                Product productoCreado = _productsService.CreateProduct(productoNuevo);
                return CreatedAtAction(nameof(CreateProduct), new { productoCreado });
            }
            catch (InvalidOperationException ex)
            {
                return Conflict(ex.Message);
            }
            catch(Exception)
            {
                return StatusCode(500,"Error no controlado");
            }
        }

        [HttpPut("{id}")]
        public ActionResult Put(int id, Product modificacionProducto)
        {
            try
            {
                var result=_productsService.UpdateProduct(id, modificacionProducto);
                return result == false ? BadRequest("Unable to Update") : Ok("Product updated");
            }
            catch (InvalidOperationException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500,ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            try
            {
                bool eliminado= _productsService.DeleteProduct(id);
                return Ok("Product Deleted Correctly");

            }
            catch (InvalidOperationException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception)
            {
                return StatusCode(500, "Unexpected Error");
            }

        }
    }
}