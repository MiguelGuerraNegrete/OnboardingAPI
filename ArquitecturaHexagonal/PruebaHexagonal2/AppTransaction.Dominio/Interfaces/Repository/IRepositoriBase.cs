using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace AppTransaction.Dominio.Interfaces.Repository
{
    public interface IRepositoriBase<Entity,EntityId> : IPost<Entity>, IUpdate<Entity>,IDelete<EntityId>,IGet<Entity, EntityId>, ITransaction
    {
    }
}
