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
    public class ProductController : ControllerBase
    {
        
        ProductService CreateService()
        {
            TransactionContext db = new TransactionContext();
            ProductRepository repo = new ProductRepository(db);
            ProductService service = new ProductService(repo);
            return service;

        }


        // GET: api/<ProductController>
        [HttpGet]
        public ActionResult<List<Product>> Get()
        {
            var service = CreateService();
            return Ok(service);
        }

        // GET api/<ProductController>/5
        [HttpGet("{id}")]
        public ActionResult<Product> Get1(int id)
        {
            var service = CreateService();
            return Ok(service.GetById(id));
        }

        // POST api/<ProductController>
        [HttpPost]
        public ActionResult Post([FromBody] Product product)
        {
            var service = CreateService();
            service.Post(product);
            return Ok("Added product");
        }

        // PUT api/<ProductController>/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Product product)
        {
            var service = CreateService();
            product.ProductId = id;
            service.Update(product);
            return Ok("Updated");
        }

        // DELETE api/<ProductController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var service = CreateService();
            service.Delete(id);
            return Ok("Deleted");
        }
    }
}
