
using TransportWebApp.Domain.Entities;

namespace TransportWebApp.Domain.Repositories;

public interface IInvoiceLineRepository
{
    Task<InvoiceLine> GetInvoiceLineAsync(int id);

    Task<List<InvoiceLine>> GetInvoiceLinesAsync();

    Task<int> CreateInvoiceLineAsync(InvoiceLine entity);

    Task UpdateInvoiceLineAsync(InvoiceLine entity);

    Task DeleteInvoiceLineAsync(int id);
}
