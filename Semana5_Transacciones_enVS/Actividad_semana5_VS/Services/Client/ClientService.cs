using Actividad_semana4_VS.Model;
using Actividad_semana5_VS.Service;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Actividad_semana4_VS.Service
{
    public class ClientService : IClientService
    {
        private readonly ProjectContext _context;

        public ClientService(ProjectContext dbcontext)
        {
            _context = dbcontext;
        }

        public async Task<IEnumerable<Client>> ObtainAllAsync() => await _context.Clients.ToListAsync();

        public async Task<Client> ObtainByIdAsync(int clientId)
        {
            var currenteClient = await _context.Clients.FindAsync(clientId);
            if (currenteClient == null)
            {
                return new Client();
            }
            return currenteClient;
        }

        public async Task SaveAsync(Client client)
        {
            await _context.AddAsync(client);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(int clientId, Client client)
        {
            var currentclient = await _context.Clients.FindAsync(clientId);

            if (currentclient != null)
            {
                currentclient.Identification = client.Identification;
                currentclient.Name = client.Name;
                currentclient.AvailableBalance = client.AvailableBalance;
                await _context.SaveChangesAsync();
            }
        }

        public async Task EraseAsync(int clientId)
        {
            var clientActual = await _context.Clients.FindAsync(clientId);

            if (clientActual != null)
            {
                _context.Remove(clientActual);
                await _context.SaveChangesAsync();
            }
        }

    }

}
