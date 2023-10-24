using Actividad_semana4_VS.Model;

namespace Actividad_semana5_VS.Service
{
    public interface IOrderService
    {
        Task<IEnumerable<Order>> ObtainAllAsync();
        Task<Order> ObtainByIdAsync(long orderId);
        Task SaveNewAsync(Order order);
        Task UpdateAsync(long orderId, Order order);
        Task EreaseAsync(long orderId);
    }
}
