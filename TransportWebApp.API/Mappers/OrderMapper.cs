using AutoMapper;
using Common.Models;
using TransportWebApp.Domain.Entities;

namespace TransportWebApp.API.Mappers;

public class OrderMapper : ITypeConverter<OrderDto, Order>
{
    public Order Convert(OrderDto source, Order destination, ResolutionContext context)
    {
        return new Order()
        {
            Id = source.Id,
            OrderNumber = source.OrderNumber,
            ClientId = source.ClientId,
            CreatedAtUtc = source.CreatedAtUtc,
            RequiredPickupUtc = source.RequiredPickupUtc,
            RequiredDeliveryUtc = source.RequiredDeliveryUtc,
            Status = source.Status,
            PickupAddress = context.Mapper.Map<Address>(source.PickupAddress),
            DeliveryAddress = context.Mapper.Map<Address>(source.DeliveryAddress),
            Notes = source.Notes,
            Items = [.. source.Items.Select(i => context.Mapper.Map<OrderItem>(i))],
            Deliveries = [.. source.Deliveries.Select(d => context.Mapper.Map<Delivery>(d))],
            Invoice = source.Invoice != null ? context.Mapper.Map<Invoice>(source.Invoice) : null
        };
    }
}
