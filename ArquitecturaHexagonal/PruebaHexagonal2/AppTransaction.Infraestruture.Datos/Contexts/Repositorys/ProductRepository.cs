using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using AppTransaction.Dominio;
using AppTransaction.Dominio.Interfaces;
using AppTransaction.Dominio.Interfaces.Repository;
using AppTransaction.Infraestruture.Datos.Contexts;

namespace AppTransaction.Infraestruture.Datos.Contexts.Repositorys
{
    public class ProductRepository : IRepositoriBase<Product, int>
    {
        private readonly TransactionContext db;

        public ProductRepository(TransactionContext _db)
        {
            db = _db;
        }
        Product IPost<Product>.Post(Product entity)
        {
            entity.ProductId = int.MaxValue;
            db.Products.Add(entity);
            return entity;
        }

        void IUpdate<Product>.Update(Product entity)
        {
            var selecProduct = db.Products.Where(c => c.ProductId == entity.ProductId).FirstOrDefault();
            if (selecProduct != null)
            {
                selecProduct.ProductName = entity.ProductName;
                selecProduct.ProductValue = entity.ProductValue;
                selecProduct.ProductCode = entity.ProductCode;

                db.Entry(selecProduct).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            }
        }

        void IDelete<int>.Delete(int entityId)
        {
            var selecProduct = db.Products.Where(c => c.ProductId == entityId).FirstOrDefault();
            if (selecProduct != null)
            {
                db.Products.Remove(selecProduct);
            }
        }

        List<Product> IGet<Product, int>.Get()
        {
            return db.Products.ToList();
        }

        Product IGet<Product, int>.GetById(int entityId)
        {
            var selecProduct = db.Products.Where(c => c.ProductId == entityId).FirstOrDefault();
            return selecProduct;
        }

        void ITransaction.SaveAllChanges()
        {
            db.SaveChanges();
        }
    }
}
