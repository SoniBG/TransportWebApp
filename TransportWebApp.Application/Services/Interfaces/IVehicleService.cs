
using Common.Models;

namespace TransportWebApp.Application.Services.Interfaces;

public interface IVehicleService
{
    Task<VehicleDto> GetVehicleAsync(int id);
    Task<List<VehicleDto>> GetVehiclesAsync();
    Task<int> CreateVehicleAsync(VehicleDto model);
    Task UpdateVehicleAsync(VehicleDto model);
    Task DeleteVehicleAsync(int id);
}
