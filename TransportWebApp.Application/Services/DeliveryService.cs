
using AutoMapper;
using Common.Models;
using TransportWebApp.Application.Services.Interfaces;
using TransportWebApp.Domain.Entities;
using TransportWebApp.Domain.Repositories;

namespace TransportWebApp.Application.Services;

public class DeliveryService : IDeliveryService
{
    private readonly IDeliveryRepository deliveryRepository;
    private readonly IMapper mapper;

    public DeliveryService(IDeliveryRepository deliveryRepository, IMapper mapper)
    {
        this.deliveryRepository = deliveryRepository;
        this.mapper = mapper;
    }

    public async Task<DeliveryDto> GetDeliveryAsync(int id)
    {
        var entity = await deliveryRepository.GetDeliveryAsync(id);
        return mapper.Map<DeliveryDto>(entity);
    }

    public async Task<List<DeliveryDto>> GetDeliveriesAsync()
    {
        var entities = await deliveryRepository.GetDeliveriesAsync();
        return mapper.Map<List<DeliveryDto>>(entities);
    }

    public async Task<int> CreateDeliveryAsync(DeliveryDto model)
    {
        var entity = mapper.Map<Delivery>(model);
        return await deliveryRepository.CreateDeliveryAsync(entity);
    }

    public async Task UpdateDeliveryAsync(DeliveryDto model)
    {
        var entity = mapper.Map<Delivery>(model);
        await deliveryRepository.UpdateDeliveryAsync(entity);
    }

    public async Task DeleteDeliveryAsync(int id)
    {
        await deliveryRepository.DeleteDeliveryAsync(id);
    }
}
