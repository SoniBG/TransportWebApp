
using Common.Models;

namespace TransportWebApp.Application.Services.Interfaces;

public interface IDriverService
{
    Task<DriverDto> GetDriverAsync(int id);
    Task<List<DriverDto>> GetDriversAsync();
    Task<int> CreateDriverAsync(DriverDto model);
    Task UpdateDriverAsync(DriverDto model);
    Task DeleteDriverAsync(int id);
}
