using Actividad_semana4_VS;
using Actividad_semana4_VS.Model;
using Microsoft.EntityFrameworkCore;

namespace Actividad_semana5_VS.Service
{
    public class OrderService : IOrderService
    {
        private readonly ProjectContext _context;

        public OrderService(ProjectContext dbcontext)
        {
            _context = dbcontext;
        }

        public async Task<IEnumerable<Order>> ObtainAllAsync() => await _context.Orders.ToListAsync();
        public async Task<Order> ObtainByIdAsync(long orderId)
        {
            var curretOrder = await _context.Orders.FindAsync(orderId);
            if (curretOrder == null)
            {
                return new Order();
            }
            return curretOrder;
        }

        public async Task SaveNewAsync(Order order)
        {
            await _context.Orders.AddAsync(order);
            await _context.SaveChangesAsync();
        }


        public async Task UpdateAsync(long orderId, Order order)
        {
            var currentOrder = await _context.Orders.FindAsync(orderId);

            if (currentOrder != null)
            {
                currentOrder.Units = order.Units;
                currentOrder.ProductValue = order.ProductValue;
                currentOrder.Client = order.Client;
                currentOrder.Product = order.Product;

                await _context.SaveChangesAsync();
            }
        }

        public async Task EreaseAsync(long orderId)
        {
            var orderActal = _context.Orders.Find(orderId);

            if (orderActal != null)
            {
                _context.Remove(orderActal);
                await _context.SaveChangesAsync();
            }
        }

    }
}
