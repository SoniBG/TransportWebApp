
using AutoMapper;
using Common.Models;
using TransportWebApp.Application.Services.Interfaces;
using TransportWebApp.Domain.Entities;
using TransportWebApp.Domain.Repositories;

namespace TransportWebApp.Application.Services;

public class InvoiceLineService : IInvoiceLineService
{
    private readonly IInvoiceLineRepository invoiceLineRepository;
    private readonly IMapper mapper;

    public InvoiceLineService(IInvoiceLineRepository invoiceLineRepository, IMapper mapper)
    {
        this.invoiceLineRepository = invoiceLineRepository;
        this.mapper = mapper;
    }

    public async Task<InvoiceLineDto> GetInvoiceLineAsync(int id)
    {
        var entity = await invoiceLineRepository.GetInvoiceLineAsync(id);
        return mapper.Map<InvoiceLineDto>(entity);
    }

    public async Task<List<InvoiceLineDto>> GetInvoiceLinesAsync()
    {
        var entities = await invoiceLineRepository.GetInvoiceLinesAsync();
        return mapper.Map<List<InvoiceLineDto>>(entities);
    }

    public async Task<int> CreateInvoiceLineAsync(InvoiceLineDto model)
    {
        var entity = mapper.Map<InvoiceLine>(model);
        return await invoiceLineRepository.CreateInvoiceLineAsync(entity);
    }

    public async Task UpdateInvoiceLineAsync(InvoiceLineDto model)
    {
        var entity = mapper.Map<InvoiceLine>(model);
        await invoiceLineRepository.UpdateInvoiceLineAsync(entity);
    }

    public async Task DeleteInvoiceLineAsync(int id)
    {
        await invoiceLineRepository.DeleteInvoiceLineAsync(id);
    }
}
