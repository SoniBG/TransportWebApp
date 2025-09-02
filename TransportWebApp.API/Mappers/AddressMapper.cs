using AutoMapper;
using Common.Models;
using TransportWebApp.Domain.Entities;

namespace TransportWebApp.API.Mappers;

public class AddressMapper : ITypeConverter<AddressDto, Address>
{
    public Address Convert(AddressDto source, Address destination, ResolutionContext context)
    {
        return new Address()
        {
            Street = source.Street,
            City = source.City,
            Country = source.Country,
            PostalCode = source.PostalCode
        };
    }
}
