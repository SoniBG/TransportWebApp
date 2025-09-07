
using Common.Models;

namespace TransportWebApp.Application.Services.Interfaces;

public interface IInvoiceService
{
    Task<InvoiceDto> GetInvoiceAsync(int id);
    Task<List<InvoiceDto>> GetInvoicesAsync();
    Task<int> CreateInvoiceAsync(InvoiceDto model);
    Task UpdateInvoiceAsync(InvoiceDto model);
    Task DeleteInvoiceAsync(int id);
}
