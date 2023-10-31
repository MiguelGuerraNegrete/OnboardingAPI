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
    public class ClientRepository : IRepositoriBase<Client, int>
    {
        private readonly TransactionContext db;

        public ClientRepository(TransactionContext _db)
        {
            db = _db;
        }

        Client IPost<Client>.Post(Client entity)
        {
            db.Clients.Add(entity);
            return entity;
        }

        void IUpdate<Client>.Update(Client entity)
        {
            var selecClient = db.Clients.Where(c => c.ClientId == entity.ClientId).FirstOrDefault();
            if (selecClient != null)
            {
                selecClient.Identification = entity.Identification;
                selecClient.Name = entity.Name;
                selecClient.AvailableBalance = entity.AvailableBalance;

                db.Entry(selecClient).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            }
        }

        void IDelete<int>.Delete(int entityId)
        {
            var selecClient = db.Clients.Where(c => c.ClientId == entityId).FirstOrDefault();
            if (selecClient != null)
            {
                db.Clients.Remove(selecClient);
            }
        }

        List<Client> IGet<Client, int>.Get()
        {
            return db.Clients.ToList();
        }

        Client IGet<Client, int>.GetById(int entityId)
        {
            var selecClient = db.Clients.Where(c => c.ClientId == entityId).FirstOrDefault();
            return selecClient;
        }

        void ITransaction.SaveAllChanges()
        {
            db.SaveChanges();
        }
    }
}
