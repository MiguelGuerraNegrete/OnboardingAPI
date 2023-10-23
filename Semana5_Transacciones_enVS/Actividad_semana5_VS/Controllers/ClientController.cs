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
            var expectedClient = await _clientService.GetClientByIdAsync(clientId);
            return Ok(expectedClient);
        }

        [HttpPost]
        public async Task<IActionResult> PostClient([FromBody] Client client)
        {
            //try
            //{
            //    await _clientService.SaveNewClientAsync(client);
            //    return CreatedAtAction(nameof(GetClientById), new { clientId = client.ClientId }, client);
            //}
            //catch (Exception ex)
            //{
            //    return StatusCode(500, $"Internal Server Error: {ex.Message}");
            //}
            await _clientService.SaveNewClientAsync(client);
            return Ok();
        }

        [HttpPut("{clientId}")]
        public async Task<IActionResult> PutClient(int clientId, [FromBody] Client client)
        {
            await _clientService.UpdateClientAsync(clientId, client);
            return Ok();
        }

        [HttpDelete("{clientId}")]
        public async Task<IActionResult> Delete(int clientId)
        {
            await _clientService.DeleteClientAsync(clientId);
            return Ok();
        }
    }
}
