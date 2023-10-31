using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppTransaction.Dominio.Interfaces.Repository
{
    public interface IRepositoryMovimiento<Entity, EntityID> : IPost<Entity>, IGet<Entity,EntityID>, ITransaction
    {
    void Cancel(EntityID entityId);
    }
}
