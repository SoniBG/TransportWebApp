using Common.Models;

namespace TransportWebApp.Application.Services.Interfaces;

public interface IClientService
{
    Task<ClientDto> GetClientAsync(int id);

    Task<List<ClientDto>> GetClientsAsync();

    Task<int> CreateClientAsync(ClientDto entity);

    Task UpdateClientAsync(ClientDto entity);

    Task DeleteClientAsync(int id);
}
