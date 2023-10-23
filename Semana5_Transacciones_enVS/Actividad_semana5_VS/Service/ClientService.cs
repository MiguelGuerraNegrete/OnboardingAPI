using Actividad_semana4_VS.Model;
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

        public async Task<IEnumerable<Client>> GetAllClientsAsync() => await _context.Clients.ToListAsync();

        public async Task<Client> GetClientByIdAsync(int clientId)
        {
            var currenteClient = await _context.Clients.FindAsync(clientId);
            return currenteClient ?? throw new Exception($"The Client ID {clientId} NOT FOUND.");
        }

        public async Task SaveNewClientAsync(Client client)
        {
            _context.Add(client);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateClientAsync(int clientId, Client client)
        {
            var currentclient = _context.Clients.Find(clientId);

            if (currentclient != null)
            {
                currentclient.Identification = client.Identification;
                currentclient.Name = client.Name;
                currentclient.AvailableBalance = client.AvailableBalance;
                await _context.SaveChangesAsync();
            }
        }

        public async Task DeleteClientAsync(int clientId)
        {
            var clientActual = _context.Clients.Find(clientId);

            if (clientActual != null)
            {
                _context.Remove(clientActual);
                await _context.SaveChangesAsync();
            }
        }

    }

    public interface IClientService
    {
        Task<IEnumerable<Client>> GetAllClientsAsync();
        Task<Client> GetClientByIdAsync(int clientId);
        Task SaveNewClientAsync(Client client);
        Task UpdateClientAsync(int ClientId, Client client);
        Task DeleteClientAsync(int ClientId);
    }
}
