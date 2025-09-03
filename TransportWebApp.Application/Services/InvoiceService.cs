using AutoMapper;
using Common.Models;
using TransportWebApp.Application.Services.Interfaces;
using TransportWebApp.Domain.Entities;
using TransportWebApp.Domain.Repositories;

namespace TransportWebApp.Application.Services;

public class InvoiceService : IInvoiceService
{
    private readonly IInvoiceRepository invoiceRepository;
    private readonly IMapper mapper;

    public InvoiceService(IInvoiceRepository invoiceRepository, IMapper mapper)
    {
        this.invoiceRepository = invoiceRepository;
        this.mapper = mapper;
    }

    public async Task<InvoiceDto> GetInvoiceAsync(int id)
    {
        var entity = await invoiceRepository.GetInvoiceAsync(id);
        return mapper.Map<InvoiceDto>(entity);
    }

    public async Task<List<InvoiceDto>> GetInvoicesAsync()
    {
        var entities = await invoiceRepository.GetInvoicesAsync();
        return mapper.Map<List<InvoiceDto>>(entities);
    }

    public async Task<int> CreateInvoiceAsync(InvoiceDto model)
    {
        var entity = mapper.Map<Invoice>(model);
        return await invoiceRepository.CreateInvoiceAsync(entity);
    }

    public async Task UpdateInvoiceAsync(InvoiceDto model)
    {
        var entity = mapper.Map<Invoice>(model);
        await invoiceRepository.UpdateInvoiceAsync(entity);
    }

    public async Task DeleteInvoiceAsync(int id)
    {
        await invoiceRepository.DeleteInvoiceAsync(id);
    }
}
