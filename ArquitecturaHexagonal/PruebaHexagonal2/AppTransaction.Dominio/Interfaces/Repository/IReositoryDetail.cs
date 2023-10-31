using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using AppTransaction.Dominio.Interfaces;

namespace AppTransaction.Dominio.Interfaces.Repository
{
    public interface IReositoryDetail<Entity, MovimientoId> : IPost<Entity>, ITransaction
    {

    }
}
