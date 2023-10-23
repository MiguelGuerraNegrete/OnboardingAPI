using Actividad_semana4_VS.Model;
using Actividad_semana4_VS.Service;
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
        public async Task<IActionResult> GetOrders()
        {
            var AllOrders = await _orderService.GetAllOrdersAsync();
            return Ok(AllOrders);
        }

        [HttpGet("{orderId}")]
        public async Task<IActionResult> GetOrderById(long orderId)
        {
            var expectedClient = await _orderService.GetOrdertByIdAsync(orderId);
            return Ok(expectedClient);
           
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Order order)
        {
            await _orderService.SaveNewOrderAsync(order);
            return Ok();
        }

        [HttpPut("{orderId}")]
        public async Task<IActionResult> Put(long orderId, [FromBody] Order order)
        {
            await _orderService.UpdateOrderAsync(orderId, order);
            return Ok();
        }

        [HttpDelete("{orderId}")]
        public async Task<IActionResult> Delete(long orderId)
        {
            await _orderService.DeleteOrderAsync(orderId);
            return Ok();
        }
    }
}
