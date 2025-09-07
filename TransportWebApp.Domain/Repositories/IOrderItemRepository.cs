using TransportWebApp.Domain.Entities;

namespace TransportWebApp.Domain.Repositories;

public interface IOrderItemRepository
{
    Task<OrderItem> GetOrderItemAsync(int id);

    Task<List<OrderItem>> GetOrderItemsAsync();

    Task<int> CreateOrderItemAsync(OrderItem entity);

    Task UpdateOrderItemAsync(OrderItem entity);

    Task DeleteOrderItemAsync(int id);
}
