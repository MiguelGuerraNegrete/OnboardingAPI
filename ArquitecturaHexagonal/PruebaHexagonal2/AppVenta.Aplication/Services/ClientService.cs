using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using AppTransaction.Dominio;
using AppTransaction.Dominio.Interfaces.Repository;
using AppTransaction.Aplication.Interfaces;
using AppTransaction.Dominio.Interfaces;

namespace AppTransaction.Aplication.Services
{
    public class ClientService : IServiceBaseClient<Client, int>
    {
        private readonly IRepositoriBase<Client, int> repoClient; 

        public ClientService(IRepositoriBase<Client, int> _repoClient)
        {
            repoClient = _repoClient;
        }

        public List<Client> Get()
        {
           return repoClient.Get();
        }

        public Client GetById(int entityId)
        {
            return repoClient.GetById(entityId);
        }

        public Client Post(Client entity)
        {
            if (entity == null)
            {         
                throw new ArgumentNullException("Client is required");
            }
            var clienResult = repoClient.Post(entity);
            repoClient.SaveAllChanges();
            return clienResult;
        }

        public void Update(Client entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("Client is required");
            }
            repoClient.Update(entity);
            repoClient.SaveAllChanges();
        }

        public void Delete(int entityId)
        {
            repoClient.Delete(entityId);
            repoClient.SaveAllChanges();
        }
    }
}
