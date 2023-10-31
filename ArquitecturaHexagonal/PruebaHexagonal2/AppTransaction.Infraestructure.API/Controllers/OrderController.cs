using Microsoft.AspNetCore.Mvc;

using AppTransaction.Dominio;
using AppTransaction.Aplication.Services;
using AppTransaction.Infraestruture.Datos.Contexts.Repositorys;
using AppTransaction.Infraestruture.Datos.Contexts;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AppTransaction.Infraestructure.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        OrderService CreateService()
        {
            TransactionContext db = new TransactionContext();
            OrderRepository repoOrder = new OrderRepository(db);
            ClientRepository repoClient = new ClientRepository(db);
            ProductRepository repoProduct = new ProductRepository(db);
            OrderService service = new OrderService(repoOrder,repoClient,repoProduct);
            return service;
        }


        // GET: api/<OrderController>
        [HttpGet]
        public ActionResult<List<Order>> Get()
        {
            var service = CreateService();
            return Ok(service);
        }

        // GET api/<OrderController>/5
        [HttpGet("{id}")]
        public ActionResult<Order> Get1(long id)
        {
            var service = CreateService();
            return Ok(service.GetById(id));
        }

        // POST api/<OrderController>
        [HttpPost]
        public ActionResult Post([FromBody] Order order)
        {
            var service = CreateService();
            service.Post(order);
            return Ok("Added order");
        }

        // DELETE api/<OrderController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(long id)
        {
            var service = CreateService();
            service.Cancel(id);
            return Ok("Deleted");
        }
    }
}
