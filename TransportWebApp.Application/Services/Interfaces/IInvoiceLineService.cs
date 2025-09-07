
using Common.Models;

namespace TransportWebApp.Application.Services.Interfaces;

public interface IInvoiceLineService
{
    Task<InvoiceLineDto> GetInvoiceLineAsync(int id);
    Task<List<InvoiceLineDto>> GetInvoiceLinesAsync();
    Task<int> CreateInvoiceLineAsync(InvoiceLineDto model);
    Task UpdateInvoiceLineAsync(InvoiceLineDto model);
    Task DeleteInvoiceLineAsync(int id);
}
