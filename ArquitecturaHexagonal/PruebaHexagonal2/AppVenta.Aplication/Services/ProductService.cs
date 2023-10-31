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
    public class ProductService : IServiceBaseProduct<Product, int>
    {
        private readonly IRepositoriBase<Product, int> repopProduct;

        public ProductService(IRepositoriBase<Product, int> _repoProduct)
        {
            repopProduct = _repoProduct;
        }

        public List<Product> Get()
        {
            return repopProduct.Get();
        }

        public Product GetById(int entityId)
        {
            return repopProduct.GetById(entityId);
        }

        public Product Post(Product entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("Product is required");
            }
            var newProduct = repopProduct.Post(entity);
            repopProduct.SaveAllChanges();
            return newProduct;
        }

        public void Update(Product entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("Product is required");
            }
            repopProduct.Update(entity);
            repopProduct.SaveAllChanges();
        }

        public void Delete(int entityId)
        {
            repopProduct.Delete(entityId);
            repopProduct.SaveAllChanges();
        }
    }
}
