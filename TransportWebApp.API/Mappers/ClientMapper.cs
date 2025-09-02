using AutoMapper;
using Common.Models;
using TransportWebApp.Domain.Entities;
namespace TransportWebApp.API.Mappers;

public class ClientMapper : ITypeConverter<ClientDto, Client>
{
    public Client Convert(ClientDto source, Client destination, ResolutionContext context)
    {
        return new Client()
        {
            Id = source.Id,
            Name = source.Name,
            Bulstat = source.Bulstat,
            VatNumber = source.VatNumber,
            Email = source.Email,
            Phone = source.Phone,
            BillingAddress = context.Mapper.Map<Address>(source.BillingAddress),
            DefaultPickupAddress = context.Mapper.Map<Address>(source.DefaultPickupAddress),
            IsActive = source.IsActive,
            CreatedAtUtc = source.CreatedAtUtc
        };
    }
}
