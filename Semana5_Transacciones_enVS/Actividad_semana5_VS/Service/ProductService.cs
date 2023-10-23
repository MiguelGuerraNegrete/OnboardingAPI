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
            var currentProduct = await _context.Products.FindAsync(productId);

            return currentProduct ?? throw new Exception($"The product ID {productId}  NOT FOUND.");
        }

        public async Task SaveProductAsync(Product product)
        {
            _context.Add(product);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateProductAsync(int ProductId, Product product)
        {
            var updatedProduct = _context.Products.Find(ProductId);

            if (updatedProduct != null)
            {
                updatedProduct.ProductCode = product.ProductCode;
                updatedProduct.ProductName = product.ProductName;
                updatedProduct.ProductValue = product.ProductValue;
                await _context.SaveChangesAsync();
            }
        }

        public async Task DeleteProductAsync(int ProductId)
        {
            var productToDelete = _context.Products.Find(ProductId);

            if (productToDelete != null)
            {
                _context.Remove(productToDelete);
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
