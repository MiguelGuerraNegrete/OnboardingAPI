using Actividad_semana4_VS.Model;
using Actividad_semana5_VS.Service;
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
        public async Task<IActionResult> GetAllAsync()
        {
            var allProducts = await _productService.ObtainAllAsync();
            return Ok(allProducts);
        }

        [HttpGet("{productId}")]
        public async Task<IActionResult> GetByIdAsync(int productId)
        {
            var expectedProduct = await _productService.ObtainByIdAsync(productId);
            return Ok(expectedProduct);
        }

        [HttpPost]
        public IActionResult PostAsync([FromBody] Product product)
        {
            _productService.SaveAsync(product);
            return Ok();
        }

        [HttpPut("{ProductId}")]
        public async Task<IActionResult> PutAsync(int ProductId, [FromBody] Product product)
        {
            await _productService.UpdateAsync(ProductId, product);
            return Ok();
        }

        [HttpDelete("{ProductId}")]
        public async Task<IActionResult> DeleteAsync(int ProductId)
        {
            await _productService.EreaseAsync(ProductId);
            return Ok();
        }
    }
}
