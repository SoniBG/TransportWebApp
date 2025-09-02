
using TransportWebApp.Domain.Entities;

namespace TransportWebApp.Domain.Repositories;

public interface IInvoiceRepository
{
    Task<Invoice> GetInvoiceAsync(int id);

    Task<List<Invoice>> GetInvoicesAsync();

    Task<int> CreateInvoiceAsync(Invoice entity);

    Task UpdateInvoiceAsync(Invoice entity);

    Task DeleteInvoiceAsync(int id);
}
