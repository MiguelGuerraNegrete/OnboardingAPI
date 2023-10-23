using Actividad_semana4_VS.Model;

namespace Actividad_semana5_VS.Service
{
    public interface IClientService
    {
        Task<IEnumerable<Client>> ObtainAllAsync();
        Task<Client> ObtainByIdAsync(int clientId);
        Task SaveAsync(Client client);
        Task UpdateAsync(int ClientId, Client client);
        Task EraseAsync(int ClientId);
    }
}
