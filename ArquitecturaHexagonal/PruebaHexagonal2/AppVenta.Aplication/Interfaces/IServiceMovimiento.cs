using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppTransaction.Dominio;
using AppTransaction.Dominio.Interfaces;

namespace AppTransaction.Aplication.Interfaces
{
    public interface IServiceMovimiento<Entity, EntityId> : IPost<Entity>, IGet<Entity, EntityId>
    {
        void Cancel(EntityId entityId);
    }
}
