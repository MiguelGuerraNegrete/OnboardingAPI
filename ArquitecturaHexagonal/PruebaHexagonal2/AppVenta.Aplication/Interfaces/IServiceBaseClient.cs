using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppTransaction.Dominio;
using AppTransaction.Dominio.Interfaces;

namespace AppTransaction.Aplication.Interfaces
{
    public interface IServiceBaseClient<Entity, EntityId> : IPost<Entity>, IUpdate<Entity>, IDelete<EntityId>, IGet<Entity, EntityId>
    {
        Client Post(Client entity);
    }
}
