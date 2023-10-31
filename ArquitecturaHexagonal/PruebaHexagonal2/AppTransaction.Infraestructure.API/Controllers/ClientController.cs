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
    public class ClientController : ControllerBase
    {
        ClientService CreateService()
        {
            TransactionContext db = new TransactionContext();
            ClientRepository repo = new ClientRepository(db);
            ClientService service = new ClientService(repo);
            return service;

        }
        
        // GET: api/<ClientController>
        [HttpGet]
        public ActionResult<List<Client>> Get()
        {
            var service = CreateService();
            return Ok(service);
        }

        // GET api/<ClientController>/5
        [HttpGet("{id}")]
        public ActionResult<Client> Get1(int id)
        {
            var service = CreateService();
            return Ok(service.GetById(id));
        }

        // POST api/<ClientController>
        [HttpPost]
        public IActionResult Post([FromBody] Client client)
        {
            var service = CreateService();
            service.Post(client);
            return Ok("Added client");
        }

        // PUT api/<ClientController>/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Client client)
        {
            var service = CreateService();
            client.ClientId = id;
            service.Update(client);
            return Ok("Updated");
        }

        // DELETE api/<ClientController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var service = CreateService();
            service.Delete(id);
            return Ok("Deleted");
        }
    }
}
