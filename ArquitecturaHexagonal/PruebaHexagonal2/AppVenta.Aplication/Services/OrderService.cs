using AppTransaction.Aplication.Interfaces;
using AppTransaction.Dominio;
using AppTransaction.Dominio.Interfaces.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppTransaction.Aplication.Services
{
    public class OrderService : IServiceMovimiento<Order, long>
    {
        private readonly IRepositoryMovimiento<Order, long> repoOrder;
        private readonly IRepositoriBase<Client, int> repoClient;
        private readonly IRepositoriBase<Product, int> repoProduct;
        //private readonly IReositoryDetail<Order,long> repoDetail;

        public OrderService(
            IRepositoryMovimiento<Order,long> _repoOrder,
            IRepositoriBase<Client, int> _repoClient,
            IRepositoriBase<Product, int> _repoProduct
            //IReositoryDetail<Order, long> _repoDetail
            
        )
        {
            repoOrder = _repoOrder;
            repoClient = _repoClient;
            repoProduct = _repoProduct;
            //repoDetail = _repoDetail;
        }

        public void Cancel(long entityId)
        {
            repoOrder.Cancel( entityId );
            repoOrder.SaveAllChanges();
        }

        public List<Order> Get()
        {
            return repoOrder.Get();
        }

        public Order GetById(long entityId)
        {
            return repoOrder.GetById(entityId);
        }   

        public Order Post(Order entity)
        {
            if (entity == null) throw new ArgumentNullException("Order is required");
            
            var newOrder = repoOrder.Post(entity);
            repoOrder.SaveAllChanges();
            return newOrder;
        }
    }
}
