using Actividad_semana4_VS.Model;
using Microsoft.EntityFrameworkCore;

namespace Actividad_semana4_VS.Service
{
    public class OrderService : IOrderService
    {
        private readonly ProjectContext _context;

        public OrderService(ProjectContext dbcontext)
        {
            _context = dbcontext;
        }

        public async Task<IEnumerable<Order>> GetAllOrdersAsync() => await _context.Orders.ToListAsync();
        public async Task<Order> GetOrdertByIdAsync(long orderId)
        {
            var curretOrder = await _context.Orders.FindAsync(orderId);
            return curretOrder ?? throw new Exception($"The order ID {orderId} NOT FOUND."); 
        }

        public async Task SaveNewOrderAsync(Order order)
        {
            _context.Orders.Add(order);
            await _context.SaveChangesAsync();
        }


        public async Task UpdateOrderAsync(long orderId, Order order)
        {
            var currentOrder = _context.Orders.Find(orderId);

            if (currentOrder != null)
            {
                currentOrder.Units = order.Units;
                currentOrder.ProductValue = order.ProductValue;
                currentOrder.Client = order.Client;
                currentOrder.Product = order.Product;

                await _context.SaveChangesAsync();
            }
        }

        public async Task DeleteOrderAsync(long orderId)
        {
            var orderActal = _context.Orders.Find(orderId);

            if (orderActal != null)
            {
                _context.Remove(orderActal);
                await _context.SaveChangesAsync();
            }
        }

    }

    public interface IOrderService
    {
        Task<IEnumerable<Order>> GetAllOrdersAsync();
        Task<Order> GetOrdertByIdAsync(long orderId);
        Task SaveNewOrderAsync(Order order);
        Task UpdateOrderAsync(long orderId, Order order);
        Task DeleteOrderAsync(long orderId);
    }
}
