using AutoMapper;
using Common.Models;
using TransportWebApp.Application.Services.Interfaces;
using TransportWebApp.Domain.Entities;
using TransportWebApp.Domain.Repositories;

namespace TransportWebApp.Application.Services;

public class VehicleService : IVehicleService
{
    private readonly IVehicleRepository vehicleRepository;
    private readonly IMapper mapper;

    public VehicleService(IVehicleRepository vehicleRepository, IMapper mapper)
    {
        this.vehicleRepository = vehicleRepository;
        this.mapper = mapper;
    }

    public async Task<VehicleDto> GetVehicleAsync(int id)
    {
        var entity = await vehicleRepository.GetVehicleAsync(id);
        return mapper.Map<VehicleDto>(entity);
    }

    public async Task<List<VehicleDto>> GetVehiclesAsync()
    {
        var entities = await vehicleRepository.GetVehiclesAsync();
        return mapper.Map<List<VehicleDto>>(entities);
    }

    public async Task<int> CreateVehicleAsync(VehicleDto model)
    {
        var entity = mapper.Map<Vehicle>(model);
        return await vehicleRepository.CreateVehicleAsync(entity);
    }

    public async Task UpdateVehicleAsync(VehicleDto model)
    {
        var entity = mapper.Map<Vehicle>(model);
        await vehicleRepository.UpdateVehicleAsync(entity);
    }

    public async Task DeleteVehicleAsync(int id)
    {
        await vehicleRepository.DeleteVehicleAsync(id);
    }
}
