using Actividad_semana4_VS.Model;
using Actividad_semana4_VS.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Actividad_semana4_VS.Controllers
{
    [Route("api/v1/[controller]")]
    public class ClientController : ControllerBase
    {

        private readonly IClientService _clientService;

        public ClientController(IClientService service)
        {
            _clientService = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetClients()
        {
            var AllClients = await _clientService.GetAllClientsAsync();
            return Ok(AllClients);
        }

        [HttpGet("{clientId}")]
        public async Task<IActionResult> GetClientById(int clientId)
        {
            var SpectedClient = await _clientService.GetClientByIdAsync(clientId);
            return Ok(SpectedClient);
        }

        [HttpPost]
        public IActionResult PostClient([FromBody] Client client)
        {
            _clientService.SaveNewClientAsync(client);
            return Ok();
        }

        [HttpPut("{clientId}")]
        public IActionResult PutClient(int clientId, [FromBody] Client client)
        {
            _clientService.UpdateClientAsync(clientId, client);
            return Ok();
        }

        [HttpDelete("{clientId}")]
        public IActionResult Delete(int clientId)
        {
            _clientService.DeleteClientAsync(clientId);
            return Ok();
        }
    }
}
