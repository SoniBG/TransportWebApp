
using Common.Models;

namespace TransportWebApp.Application.Services.Interfaces;

public interface IDeliveryService
{
    Task<DeliveryDto> GetDeliveryAsync(int id);
    Task<List<DeliveryDto>> GetDeliveriesAsync();
    Task<int> CreateDeliveryAsync(DeliveryDto model);
    Task UpdateDeliveryAsync(DeliveryDto model);
    Task DeleteDeliveryAsync(int id);
}
