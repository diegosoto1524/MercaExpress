using Microsoft.AspNetCore.Mvc;
using Entities;
using MercaExpress.Services;

namespace MercaExpress.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ClientController:ControllerBase
    {
        private readonly IClientService _clientService;
        private readonly ILogger<ClientController> _logger;

        public ClientController (IClientService clientService, ILogger<ClientController> logger)
        {
            _clientService = clientService;
            _logger = logger;
        }

        [HttpGet]
        public ActionResult GetAllClients()
        {   
            return Ok(_clientService.GetAllClients());
        }

        [HttpPost]
        public ActionResult CreateClient(Client client)
        {
            try
            {
                bool created = _clientService.CreateClient(client);
                return CreatedAtAction("GetClientById", new { id = client.Id }, client);
            }
            catch (InvalidOperationException ex)
            {
                return Conflict(ex.Message);
            }
        }

        [HttpGet("id")]
        public ActionResult GetClientById(int id)
        {
            Client client = _clientService.GetClientById(id);
            if (client == null)
            {
                return NotFound("Client does not exist, please verify");
            }
            return Ok(client);
        }
        [HttpDelete("id")]
        public ActionResult DeleteClientById(int id)
        {
            try
            {
                bool deleted = _clientService.DeleteClient(id);
                return Ok($"client deleted :{deleted}");
            }
            catch (InvalidOperationException ex)
            {
                return Conflict(ex.Message);
            }
        }

        [HttpPut("id")]
        public ActionResult ModifyClient(int id, Client client)
        {
            try
            {
                bool modified = _clientService.ModifyCLient(id, client);
                return Ok($"product modified: {modified}");
            }
            catch (InvalidOperationException ex)
            {
                return Conflict(ex.Message);
            }
        }
    }
}
