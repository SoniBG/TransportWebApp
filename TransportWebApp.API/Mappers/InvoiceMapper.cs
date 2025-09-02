using AutoMapper;
using Common.Models;
using TransportWebApp.Domain.Entities;

namespace TransportWebApp.API.Mappers;

public class InvoiceMapper : ITypeConverter<InvoiceDto, Invoice>
{
    public Invoice Convert(InvoiceDto source, Invoice destination, ResolutionContext context)
    {
        return new Invoice()
        {
            Id = source.Id,
            InvoiceNumber = source.InvoiceNumber,
            ClientId = source.ClientId,
            OrderId = source.OrderId,
            IssueDateUtc = source.IssueDateUtc,
            DueDateUtc = source.DueDateUtc,
            Status = source.Status,
            Subtotal = source.Subtotal,
            TaxRate = source.TaxRate,
            TaxAmount = source.TaxAmount,
            Total = source.Total,
            Lines = [.. source.Lines.Select(l => context.Mapper.Map<InvoiceLine>(l))]
        };
    }
}
