
using AutoMapper;
using Common.Models;
using TransportWebApp.Application.Services.Interfaces;
using TransportWebApp.Domain.Entities;
using TransportWebApp.Domain.Repositories;

namespace TransportWebApp.Application.Services;

public class ClientService : IClientService
{
    private readonly IClientRepository clientRepository;
    private readonly IMapper mapper;

    public ClientService(IClientRepository clientRepository, IMapper mapper)
    {
        this.clientRepository = clientRepository;
        this.mapper = mapper;
    }

    public async Task<ClientDto> GetClientAsync(int id)
    {
        var entity = await clientRepository.GetClientAsync(id);
        return mapper.Map<ClientDto>(entity);
    }

    public async Task<List<ClientDto>> GetClientsAsync()
    {
        var entities = await clientRepository.GetClientsAsync();

        return mapper.Map<List<ClientDto>>(entities);
    }

    public async Task<int> CreateClientAsync(ClientDto model)
    {
        var entity = mapper.Map<Client>(model);

        return await clientRepository.CreateClientAsync(entity);
    }

    public async Task UpdateClientAsync(ClientDto model)
    {
        var entity = mapper.Map<Client>(model);

        await clientRepository.UpdateClientAsync(entity);
    }

    public async Task DeleteClientAsync(int id)
    {
        await clientRepository.DeleteClientAsync(id);
    }
}
