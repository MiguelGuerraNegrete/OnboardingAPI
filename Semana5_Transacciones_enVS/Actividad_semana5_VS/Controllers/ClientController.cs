using Actividad_semana4_VS.Model;
using Actividad_semana5_VS.Service;
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
        public async Task<IActionResult> GetAsync()
        {
            var allClients = await _clientService.ObtainAllAsync();
            return Ok(allClients);
        }

        [HttpGet("{clientId}")]
        public async Task<IActionResult> GetProductByIdAsync(int clientId)
        {
            var expectedClient = await _clientService.ObtainByIdAsync(clientId);
            return Ok(expectedClient);
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] Client client)
        {
            await _clientService.SaveAsync(client);
            return Ok();
        }

        [HttpPut("{clientId}")]
        public async Task<IActionResult> PutAsync(int clientId, [FromBody] Client client)
        {
            await _clientService.UpdateAsync(clientId, client);
            return Ok();
        }

        [HttpDelete("{clientId}")]
        public async Task<IActionResult> DeleteProductAsync(int clientId)
        {
            await _clientService.EraseAsync(clientId);
            return Ok();
        }
    }
}
