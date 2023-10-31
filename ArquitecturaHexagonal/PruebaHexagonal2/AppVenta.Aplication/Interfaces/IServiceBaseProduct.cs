using AppTransaction.Dominio;
using AppTransaction.Dominio.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppTransaction.Aplication.Interfaces
{
    public interface IServiceBaseProduct<Entity, EntityId> : IPost<Entity>, IUpdate<Entity>, IDelete<EntityId>, IGet<Entity, EntityId>
    {
        Product Post(Product entity);
    }
}
