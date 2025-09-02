using AutoMapper;
using Common.Models;
using TransportWebApp.Domain.Entities;

namespace TransportWebApp.API.Mappers;

public class VehicleMapper : ITypeConverter<VehicleDto, Vehicle>
{
    public Vehicle Convert(VehicleDto source, Vehicle destination, ResolutionContext context)
    {
        return new Vehicle()
        {
            Id = source.Id,
            PlateNumber = source.PlateNumber,
            Type = source.Type,
            CapacityKg = source.CapacityKg,
            VolumeM3 = source.VolumeM3,
            Make = source.Make,
            Model = source.Model,
            Year = source.Year,
            IsActive = source.IsActive
        };
    }
}
