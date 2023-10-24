
using Actividad_semana4_VS.Model;

namespace Actividad_semana5_VS.Service
{
    public interface IProductService
    {
        Task<IEnumerable<Product>> ObtainAllAsync();
        Task<Product> ObtainByIdAsync(int productId);
        Task SaveAsync(Product product);
        Task UpdateAsync(int ProductId, Product product);
        Task EreaseAsync(int ProductId);
    }
}
