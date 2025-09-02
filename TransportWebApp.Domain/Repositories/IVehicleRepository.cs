
using TransportWebApp.Domain.Entities;

namespace TransportWebApp.Domain.Repositories;

public interface IVehicleRepository
{
    Task<Vehicle> GetVehicleAsync(int id);

    Task<List<Vehicle>> GetVehiclesAsync();

    Task<int> CreateVehicleAsync(Vehicle entity);

    Task UpdateVehicleAsync(Vehicle entity);

    Task DeleteVehicleAsync(int id);
}
