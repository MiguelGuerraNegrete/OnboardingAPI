using Actividad_semana4_VS.Model;
using Actividad_semana4_VS.Service;
using Microsoft.AspNetCore.Mvc;

namespace Actividad_semana4_VS.Controllers
{
    [Route("api/v1/[controller]")]
    public class ProductController : ControllerBase
    {
        IProductService productService;

        public ProductController(IProductService service)
        {
            productService = service;
        }

        [HttpGet]
        public IActionResult GetProduct()
        {
            return Ok(productService.GetAllProductsAsync());
        }

        [HttpPost]
        public IActionResult PostProduct([FromBody] Product product)
        {
            productService.SaveProductAsync(product);
            return Ok();
        }

        [HttpPut("{ProductId}")]
        public IActionResult PutProduct(int ProductId, [FromBody] Product product)
        {
            productService.UpdateProductAsync(ProductId, product);
            return Ok();
        }

        [HttpDelete("{ProductId}")]
        public IActionResult DeleteProduct(int ProductId)
        {
            productService.DeleteProductAsync(ProductId);
            return Ok();
        }
    }
}
