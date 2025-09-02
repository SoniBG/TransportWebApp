
using TransportWebApp.Domain.Entities;

namespace TransportWebApp.Domain.Repositories;

public interface IDriverRepository
{
    Task<Driver> GetDriverAsync(int id);

    Task<List<Driver>> GetDriversAsync();

    Task<int> CreateDriverAsync(Driver entity);

    Task UpdateDriverAsync(Driver entity);

    Task DeleteDriverAsync(int id);
}
