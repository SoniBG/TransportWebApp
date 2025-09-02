using TransportWebApp.Domain.Entities;

namespace TransportWebApp.Domain.Repositories;

public interface IClientRepository
{
    Task<Client> GetClientAsync(int id);

    Task<List<Client>> GetClientsAsync();

    Task<int> CreateClientAsync(Client entity);

    Task UpdateClientAsync(Client entity);

    Task DeleteClientAsync(int id);
}
