using Actividad_semana4_VS.Model;
using Actividad_semana5_VS.Service;
using Microsoft.AspNetCore.Mvc;

namespace Actividad_semana4_VS.Controllers
{
    [Route("api/v1/[controller]")]
    public class OrderController : ControllerBase
    {
        private readonly ProjectContext dbcontext;
        private readonly IOrderService _orderService;

        public OrderController(IOrderService service, ProjectContext db)
        {
            _orderService = service;
            dbcontext = db;
        }

        [HttpGet]
        [Route("/createdb")]
        public IActionResult CraeteDtabase()
        {
            dbcontext.Database.EnsureCreated();
            return Ok();
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var allOrders = await _orderService.ObtainAllAsync();
            return Ok(allOrders);
        }

        [HttpGet("{orderId}")]
        public async Task<IActionResult> GetByIdAsync(long orderId)
        {
            var expectedClient = await _orderService.ObtainByIdAsync(orderId);
            return Ok(expectedClient);
           
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] Order order)
        {
            await _orderService.SaveNewAsync(order);
            return Ok();
        }

        [HttpPut("{orderId}")]
        public async Task<IActionResult> PutAsync(long orderId, [FromBody] Order order)
        {
            await _orderService.UpdateAsync(orderId, order);
            return Ok();
        }

        [HttpDelete("{orderId}")]
        public async Task<IActionResult> DeleteAsync(long orderId)
        {
            await _orderService.EreaseAsync(orderId);
            return Ok();
        }
    }
}
