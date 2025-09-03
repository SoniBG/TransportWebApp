using AutoMapper;
using Common.Models;
using TransportWebApp.Application.Services.Interfaces;
using TransportWebApp.Domain.Entities;
using TransportWebApp.Domain.Repositories;

namespace TransportWebApp.Application.Services;

public class DriverService : IDriverService
{
    private readonly IDriverRepository driverRepository;
    private readonly IMapper mapper;

    public DriverService(IDriverRepository driverRepository, IMapper mapper)
    {
        this.driverRepository = driverRepository;
        this.mapper = mapper;
    }

    public async Task<DriverDto> GetDriverAsync(int id)
    {
        var entity = await driverRepository.GetDriverAsync(id);
        return mapper.Map<DriverDto>(entity);
    }

    public async Task<List<DriverDto>> GetDriversAsync()
    {
        var entities = await driverRepository.GetDriversAsync();
        return mapper.Map<List<DriverDto>>(entities);
    }

    public async Task<int> CreateDriverAsync(DriverDto model)
    {
        var entity = mapper.Map<Driver>(model);
        return await driverRepository.CreateDriverAsync(entity);
    }

    public async Task UpdateDriverAsync(DriverDto model)
    {
        var entity = mapper.Map<Driver>(model);
        await driverRepository.UpdateDriverAsync(entity);
    }

    public async Task DeleteDriverAsync(int id)
    {
        await driverRepository.DeleteDriverAsync(id);
    }
}
