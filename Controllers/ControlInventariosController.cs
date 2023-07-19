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

        [HttpPut()]
        public ActionResult AgregarAInventarioBodega([FromQuery] List<Product> listadoProductos, [FromRoute] List<int> listadoCantidades)
        {
            List <int> cantidadesNuevasEnBodega=_inventariosService.AgregarAInventarioBodega(listadoProductos, listadoCantidades);
            return Ok(cantidadesNuevasEnBodega);
        }


    }
}
