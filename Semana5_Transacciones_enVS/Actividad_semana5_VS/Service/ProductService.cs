using Actividad_semana4_VS.Model;
using Microsoft.EntityFrameworkCore;

namespace Actividad_semana4_VS.Service
{
    public class ProductService : IProductService
    {
        private readonly ProjectContext _context;

        public ProductService(ProjectContext dbcontext)
        {
            _context = dbcontext;
        }
        public async Task<IEnumerable<Product>> GetAllProductsAsync() => await _context.Products.ToListAsync();

        public async Task<Product> GetProductByIdAsync(int productId)
        {
            var currenteProduct = await _context.Products.FindAsync(productId);

            if (currenteProduct == null)
            {
                throw new Exception($"El Cliente con  el ID {productId} no encontrado.");
            }
            return currenteProduct;
        }

        public async Task SaveProductAsync(Product product)
        {
            _context.Add(product);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateProductAsync(int ProductId, Product product)
        {
            var productActual = _context.Products.Find(ProductId);

            if (productActual != null)
            {
                productActual.ProductCode = product.ProductCode;
                productActual.ProductName = product.ProductName;
                productActual.ProductValue = product.ProductValue;
                await _context.SaveChangesAsync();
            }
        }

        public async Task DeleteProductAsync(int ProductId)
        {
            var productActual = _context.Products.Find(ProductId);

            if (productActual != null)
            {
                _context.Remove(productActual);
                await _context.SaveChangesAsync();
            }
        }
    }

    public interface IProductService
    {
        Task<IEnumerable<Product>> GetAllProductsAsync();
        Task<Product> GetProductByIdAsync(int productId);
        Task SaveProductAsync(Product product);
        Task UpdateProductAsync(int ProductId, Product product);
        Task DeleteProductAsync(int ProductId);
    }
}
