
using Common.Models;

namespace TransportWebApp.Application.Services.Interfaces;

public interface IOrderItemService
{
    Task<OrderItemDto> GetOrderItemAsync(int id);
    Task<List<OrderItemDto>> GetOrderItemsAsync();
    Task<int> CreateOrderItemAsync(OrderItemDto model);
    Task UpdateOrderItemAsync(OrderItemDto model);
    Task DeleteOrderItemAsync(int id);
}
