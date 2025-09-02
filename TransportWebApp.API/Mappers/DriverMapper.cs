using AutoMapper;
using Common.Models;
using TransportWebApp.Domain.Entities;

namespace TransportWebApp.API.Mappers;

public class DriverMapper : ITypeConverter<DriverDto, Driver>
{
    public Driver Convert(DriverDto source, Driver destination, ResolutionContext context)
    {
        return new Driver()
        {
            Id = source.Id,
            FirstName = source.FirstName,
            LastName = source.LastName,
            Email = source.Email,
            Phone = source.Phone,
            ApplicationUserId = source.ApplicationUserId,
            IsActive = source.IsActive
        };
    }
}
