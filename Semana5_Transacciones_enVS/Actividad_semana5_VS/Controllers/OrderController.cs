using Actividad_semana4_VS.Model;
using Actividad_semana4_VS.Service;
using Microsoft.AspNetCore.Mvc;

namespace Actividad_semana4_VS.Controllers
{
    [Route("api/v1/[controller]")]
    public class OrderController : ControllerBase
    {
        private readonly ProjectContext dbcontext;
        private readonly IOrderService orderService;

        public OrderController(IOrderService service, ProjectContext db)
        {
            orderService = service;
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
        public IActionResult GetOrders()
        {
            return Ok(orderService.GetAllOrdersAsync());
        }

        [HttpGet("{orderId}")]
        public IActionResult GetOrderById(long orderId)
        {
            return Ok(orderService.GetOrdertByIdAsync(orderId));
        }

        [HttpPost]
        public IActionResult Post([FromBody] Order order)
        {
            orderService.SaveNewOrderAsync(order);
            return Ok();
        }

        [HttpPut("{orderId}")]
        public IActionResult Put(long orderId, [FromBody] Order order)
        {
            orderService.UpdateOrderAsync(orderId, order);
            return Ok();
        }

        [HttpDelete("{orderId}")]
        public IActionResult Delete(long orderId)
        {
            orderService.DeleteOrderAsync(orderId);
            return Ok();
        }
    }
}
