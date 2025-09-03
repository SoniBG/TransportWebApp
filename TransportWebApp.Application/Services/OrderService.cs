using AutoMapper;
using Common.Models;
using TransportWebApp.Application.Services.Interfaces;
using TransportWebApp.Domain.Entities;
using TransportWebApp.Domain.Repositories;

namespace TransportWebApp.Application.Services;

public class OrderService : IOrderService
{
    private readonly IOrderRepository orderRepository;
    private readonly IMapper mapper;

    public OrderService(IOrderRepository orderRepository, IMapper mapper)
    {
        this.orderRepository = orderRepository;
        this.mapper = mapper;
    }

    public async Task<OrderDto> GetOrderAsync(int id)
    {
        var entity = await orderRepository.GetOrderAsync(id);
        return mapper.Map<OrderDto>(entity);
    }

    public async Task<List<OrderDto>> GetOrdersAsync()
    {
        var entities = await orderRepository.GetOrdersAsync();
        return mapper.Map<List<OrderDto>>(entities);
    }

    public async Task<int> CreateOrderAsync(OrderDto model)
    {
        var entity = mapper.Map<Order>(model);
        return await orderRepository.CreateOrderAsync(entity);
    }

    public async Task UpdateOrderAsync(OrderDto model)
    {
        var entity = mapper.Map<Order>(model);
        await orderRepository.UpdateOrderAsync(entity);
    }

    public async Task DeleteOrderAsync(int id)
    {
        await orderRepository.DeleteOrderAsync(id);
    }
}
