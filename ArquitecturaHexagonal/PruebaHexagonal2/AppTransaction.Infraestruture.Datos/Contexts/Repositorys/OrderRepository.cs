using AppTransaction.Dominio;
using AppTransaction.Dominio.Interfaces.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppTransaction.Infraestruture.Datos.Contexts.Repositorys
{
    public class OrderRepository : IRepositoryMovimiento<Order, long>
    {
        private readonly TransactionContext db;

        public OrderRepository(TransactionContext _db)
        {
            db = _db;
        }

        public void Cancel(long entityId)
        {
            var orderSelec = db.Orders.Where(c => c.OrderId == entityId).FirstOrDefault();
            
            if(orderSelec != null) 
            {
                throw new InvalidOperationException("Order not exist");
            }

            orderSelec.Canceled = true;
            db.Entry(orderSelec).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
        }

        public List<Order> Get()
        {
            return db.Orders.ToList();
        }

        public Order GetById(long entityId)
        {
            var selecOrder = db.Orders.Where(c => c.OrderId == entityId).FirstOrDefault();
            return selecOrder;
        }

        public Order Post(Order entity)
        {
            entity.OrderId = int.MaxValue;
            db.Orders.Add(entity);
            return entity;
        }

        public void SaveAllChanges()
        {
            db.SaveChanges();
        }
    }
}
