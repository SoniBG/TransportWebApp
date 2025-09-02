using AutoMapper;
using Common.Models;
using TransportWebApp.Domain.Entities;

namespace TransportWebApp.API.Mappers;

public class InvoiceLineMapper : ITypeConverter<InvoiceLineDto, InvoiceLine>
{
    public InvoiceLine Convert(InvoiceLineDto source, InvoiceLine destination, ResolutionContext context)
    {
        return new InvoiceLine()
        {
            Id = source.Id,
            InvoiceId = source.InvoiceId,
            Description = source.Description,
            Quantity = source.Quantity,
            UnitPrice = source.UnitPrice,
            LineTotal = source.LineTotal
        };
    }
}
