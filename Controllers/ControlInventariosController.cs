using Entities;
using MercaExpress.Services;
using Microsoft.AspNetCore.Mvc;
 
namespace MercaExpress.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ControlInventariosController:ControllerBase
    {
        private readonly IInventariosService _inventariosService;
        private readonly ILogger<ControlInventariosController> _logger;

        public ControlInventariosController(ILogger<ControlInventariosController> logger,IInventariosService inventariosService)
        {
            _inventariosService = inventariosService;
            _logger = logger;
        }   

        [HttpPut("Agregar a Inventario Bodega")]
        public ActionResult AgregarAInventarioBodega([FromBody] List<int> listadoProductos, [FromQuery] List <double> listadoCantidades)
        {
            //List <int> cantidades = listadoCantidades.Split(',').Select(int.Parse).ToList();
            try
            {
                List<double> cantidadesNuevasEnBodega = _inventariosService.AgregarAInventarioBodega(listadoProductos, listadoCantidades);
                return Ok(cantidadesNuevasEnBodega);
            }
            catch (InvalidOperationException ex)
            {
                return Conflict(ex.Message);
            }
        }

        [HttpGet()]
        public ActionResult GetInventarioBodegaById(int id)
        {
            int cantidadEnBodega = _inventariosService.GetInventarioBodegaById(id);
            return Ok(cantidadEnBodega) ;   
        }

        [HttpPut("Sacar de Inventario Bodega")]
        public ActionResult SacarDeInventarioBodega ([FromBody] List<ProductQuantity> productQuantity)
        {
            try
            {
                List<double> cantidadesNuevasEnBodega = _inventariosService.SacarDeInventarioBodega(productQuantity);
                return Ok(cantidadesNuevasEnBodega);
            }
            catch (InvalidOperationException ex)
            {
                return Conflict (ex.Message);
            }
        }

        [HttpPut("Agregar a Inventario Exhibicion")]
        public ActionResult AgregarAInventarioExhibicion([FromBody] List<int> listadoProductos, [FromQuery] List<int> listadoCantidades)
        {
            //List <int> cantidades = listadoCantidades.Split(',').Select(int.Parse).ToList();
            try
            {
                List<int> cantidadesNuevasEnExhibicion = _inventariosService.AgregarAInventarioExhibicion(listadoProductos, listadoCantidades);
                return Ok(cantidadesNuevasEnExhibicion);
            }
            catch (InvalidOperationException ex)
            {
                return Conflict(ex.Message);
            }
        }

        [HttpGet("Get Inventario Exhibicion por Id")]
        public ActionResult GetInventarioExhibicionById(int id)
        {
            int cantidad = _inventariosService.GetInventarioExhibicionById(id);
            return Ok(cantidad);
        }

        [HttpPut("Sacar de Inventario Exhibicion")]
        public ActionResult SacarDeInventarioExhibicion([FromBody] List<int> listadoProductos, [FromQuery] List<int> listadoCantidades)
        {
            try
            {
                List<int> cantidadesNuevas = _inventariosService.SacarDeInventarioExhibicion(listadoProductos, listadoCantidades);
                return Ok(cantidadesNuevas);
            }
            catch (InvalidOperationException ex)
            {
                return Conflict(ex.Message);
            }
        }

    }
}
