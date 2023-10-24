using Actividad_semana4_VS;
using Actividad_semana4_VS.Model;
using Microsoft.EntityFrameworkCore;

namespace Actividad_semana5_VS.Service
{
    public class ProductService : IProductService
    {
        private readonly ProjectContext _context;

        public ProductService(ProjectContext dbcontext)
        {
            _context = dbcontext;
        }

        public async Task<IEnumerable<Product>> ObtainAllAsync() => await _context.Products.ToListAsync();

        public async Task<Product> ObtainByIdAsync(int productId)
        {
            var currentProduct = await _context.Products.FindAsync(productId);
            if (currentProduct == null)
            {
                return new Product(); 
            }
            return currentProduct;
        }

        public async Task SaveAsync(Product product)
        {
            await _context.AddAsync(product);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(int ProductId, Product product)
        {
            var updatedProduct = await _context.Products.FindAsync(ProductId);

            if (updatedProduct != null)
            {
                updatedProduct.ProductCode = product.ProductCode;
                updatedProduct.ProductName = product.ProductName;
                updatedProduct.ProductValue = product.ProductValue;
                await _context.SaveChangesAsync();
            }
        }

        public async Task EreaseAsync(int ProductId)
        {
            var productToDelete = await _context.Products.FindAsync(ProductId);

            if (productToDelete != null)
            {
                _context.Remove(productToDelete);
                await _context.SaveChangesAsync();
            }
        }
    }
}
