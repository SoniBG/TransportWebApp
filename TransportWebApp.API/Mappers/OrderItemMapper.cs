using AutoMapper;
using Common.Models;
using TransportWebApp.Domain.Entities;

namespace TransportWebApp.API.Mappers;

public class OrderItemMapper : ITypeConverter<OrderItemDto, OrderItem>
{
    public OrderItem Convert(OrderItemDto source, OrderItem destination, ResolutionContext context)
    {
        return new OrderItem()
        {
            Id = source.Id,
            OrderId = source.OrderId,
            GoodId = source.GoodId,
            Quantity = source.Quantity,
            UnitPrice = source.UnitPrice,
            LineTotal = source.LineTotal
        };
    }
}
