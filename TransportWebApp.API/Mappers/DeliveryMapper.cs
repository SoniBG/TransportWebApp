using AutoMapper;
using Common.Models;
using TransportWebApp.Domain.Entities;

namespace TransportWebApp.API.Mappers;

public class DeliveryMapper : ITypeConverter<DeliveryDto, Delivery>
{
    public Delivery Convert(DeliveryDto source, Delivery destination, ResolutionContext context)
    {
        return new Delivery()
        {
            Id = source.Id,
            OrderId = source.OrderId,
            VehicleId = source.VehicleId,
            DriverId = source.DriverId,
            TrackingCode = source.TrackingCode,
            ScheduledPickupUtc = source.ScheduledPickupUtc,
            ActualPickupUtc = source.ActualPickupUtc,
            ScheduledDropoffUtc = source.ScheduledDropoffUtc,
            ActualDropoffUtc = source.ActualDropoffUtc,
            Status = source.Status,
            Notes = source.Notes
        };
    }
}
