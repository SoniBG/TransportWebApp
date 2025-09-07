using AutoMapper;
using Common.Models;
using TransportWebApp.Application.Services.Interfaces;
using TransportWebApp.Domain.Entities;
using TransportWebApp.Domain.Repositories;

namespace TransportWebApp.Application.Services;

public class OrderItemService : IOrderItemService
{
    private readonly IOrderItemRepository orderItemRepository;
    private readonly IMapper mapper;

    public OrderItemService(IOrderItemRepository orderItemRepository, IMapper mapper)
    {
        this.orderItemRepository = orderItemRepository;
        this.mapper = mapper;
    }

    public async Task<OrderItemDto> GetOrderItemAsync(int id)
    {
        var entity = await orderItemRepository.GetOrderItemAsync(id);
        return mapper.Map<OrderItemDto>(entity);
    }

    public async Task<List<OrderItemDto>> GetOrderItemsAsync()
    {
        var entities = await orderItemRepository.GetOrderItemsAsync();
        return mapper.Map<List<OrderItemDto>>(entities);
    }

    public async Task<int> CreateOrderItemAsync(OrderItemDto model)
    {
        var entity = mapper.Map<OrderItem>(model);
        return await orderItemRepository.CreateOrderItemAsync(entity);
    }

    public async Task UpdateOrderItemAsync(OrderItemDto model)
    {
        var entity = mapper.Map<OrderItem>(model);
        await orderItemRepository.UpdateOrderItemAsync(entity);
    }

    public async Task DeleteOrderItemAsync(int id)
    {
        await orderItemRepository.DeleteOrderItemAsync(id);
    }
}
