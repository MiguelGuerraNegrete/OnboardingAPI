using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppTransaction.Dominio.Interfaces
{
    public interface IUpdate<Entity>
    {
        void Update(Entity entity);
    }
}
