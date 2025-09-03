using Common.Models;

namespace TransportWebApp.Application.Services.Interfaces;

public interface IOrderService
{
    Task<OrderDto> GetOrderAsync(int id);
    Task<List<OrderDto>> GetOrdersAsync();
    Task<int> CreateOrderAsync(OrderDto model);
    Task UpdateOrderAsync(OrderDto model);
    Task DeleteOrderAsync(int id);
}
