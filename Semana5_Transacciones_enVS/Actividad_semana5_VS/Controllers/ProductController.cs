using Actividad_semana4_VS.Model;
using Actividad_semana4_VS.Service;
using Microsoft.AspNetCore.Mvc;

namespace Actividad_semana4_VS.Controllers
{
    [Route("api/v1/[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService service)
        {
            _productService = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetProduct()
        {
            var AllProducts = await _productService.GetAllProductsAsync();
            return Ok(AllProducts);
        }

        [HttpGet("{productId}")]
        public async Task<IActionResult> GetProductById(int productId)
        {
            var expectedProduct = await _productService.GetProductByIdAsync(productId);
            return Ok(expectedProduct);
        }

        [HttpPost]
        public IActionResult PostProduct([FromBody] Product product)
        {
            _productService.SaveProductAsync(product);
            return Ok();
        }

        [HttpPut("{ProductId}")]
        public async Task<IActionResult> PutProduct(int ProductId, [FromBody] Product product)
        {
            await _productService.UpdateProductAsync(ProductId, product);
            return Ok();
        }

        [HttpDelete("{ProductId}")]
        public async Task<IActionResult> DeleteProduct(int ProductId)
        {
            await _productService.DeleteProductAsync(ProductId);
            return Ok();
        }
    }
}
