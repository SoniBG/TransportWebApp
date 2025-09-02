
using TransportWebApp.Domain.Entities;

namespace TransportWebApp.Domain.Repositories;

public interface IDeliveryRepository
{
    Task<Delivery> GetDeliveryAsync(int id);

    Task<List<Delivery>> GetDeliveriesAsync();

    Task<int> CreateDeliveryAsync(Delivery entity);

    Task UpdateDeliveryAsync(Delivery entity);

    Task DeleteDeliveryAsync(int id);
}
