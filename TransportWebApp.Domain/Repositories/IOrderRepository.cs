
using TransportWebApp.Domain.Entities;

namespace TransportWebApp.Domain.Repositories;

public interface IOrderRepository
{
    Task<Order> GetOrderAsync(int id);

    Task<List<Order>> GetOrdersAsync();

    Task<int> CreateOrderAsync(Order entity);

    Task UpdateOrderAsync(Order entity);

    Task DeleteOrderAsync(int id);
}
