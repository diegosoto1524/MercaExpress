using Entities;
using MercaExpress.Services;
using Microsoft.AspNetCore.Mvc;

namespace MercaExpress.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SuplierController : ControllerBase
    {

        private readonly ILogger<SuplierController> _logger;
        private readonly ISuplierService _suplierService;

        public SuplierController(ILogger<SuplierController> logger, ISuplierService suplierService)
        {
            _logger = logger;
            _suplierService = suplierService;
        }



        [HttpPost]
        public ActionResult CreateSuplier(Suplier suplier)
        {
            try
            {
                _suplierService.CreateSuplier(suplier);
                return CreatedAtAction("GetSuplierById", new { id = suplier.Id }, suplier);
            }
            catch (InvalidOperationException ex)
            {
                return Conflict(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }


        [HttpGet]
        public ActionResult GetSupliers()
        {
            try
            {
                List<Suplier> supliers = _suplierService.GetSupliers();
                return Ok(supliers);
            }
            catch (InvalidOperationException ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        [HttpGet("Id")]
        public ActionResult GetSuplierById(int id)
        {
            try
            {
                Suplier suplier = _suplierService.GetSuplierById(id);
                return Ok(suplier);
            }
            catch (InvalidOperationException ex)
            {
                return Conflict(ex.Message);
            }
            catch (Exception exception)
            {
                return StatusCode(500, exception.Message);
            }

        }


        [HttpPut]
        public ActionResult UpdateSuplier(Suplier suplier)
        {
            try
            {
                _suplierService.UpdateSuplier(suplier);
                return CreatedAtRoute("GetSuplierById", new { id = suplier.Id }, suplier);
            }
            catch (InvalidOperationException ex)
            {
                return Conflict(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpDelete("Id")]
        public ActionResult DeleteSuplier(Suplier suplier)
        {
            try
            {
                _suplierService.DeleteSuplier(suplier);
                return Ok("Suplier deleted");
            }
            catch (InvalidOperationException ex)
            {
                return Conflict(ex.Message);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

    }
}
