
using Microsoft.EntityFrameworkCore;
using TransportWebApp.Domain.Entities;
using TransportWebApp.Domain.Exceptions;
using TransportWebApp.Domain.Repositories;
using TransportWebApp.Persistence.Data;

namespace TransportWebApp.Persistence.Reposirories;

public class InvoiceRepository : IInvoiceRepository
{
    private readonly ApplicationDbContext dbContext;

    public InvoiceRepository(ApplicationDbContext dbContext)
    {
        this.dbContext = dbContext;
    }

    public async Task<Invoice> GetInvoiceAsync(int id)
    {
        var entity = await dbContext.Invoices.AsNoTracking()
            .Include(i => i.Client)
            .Include(i => i.Order)
            .Include(i => i.Lines)
            .FirstOrDefaultAsync(i => i.Id == id) ?? throw new NotFoundException($"Item with {id} was not found");

        return entity;
    }

    public async Task<List<Invoice>> GetInvoicesAsync()
    {
        return await dbContext.Invoices.AsNoTracking()
            .Include(i => i.Client)
            .Include(i => i.Order)
            .Include(i => i.Lines)
            .ToListAsync();
    }

    public async Task<int> CreateInvoiceAsync(Invoice entity)
    {
        await dbContext.Invoices.AddAsync(entity);
        await dbContext.SaveChangesAsync();
        return entity.Id;
    }

    public async Task UpdateInvoiceAsync(Invoice entity)
    {
        var itemToUpdate = await dbContext.Invoices.FindAsync(entity.Id)
            ?? throw new NotFoundException($"Item with Id {entity.Id} was not found");

        itemToUpdate.InvoiceNumber = entity.InvoiceNumber;
        itemToUpdate.OrderId = entity.OrderId;
        itemToUpdate.ClientId = entity.ClientId;
        itemToUpdate.IssueDateUtc = entity.IssueDateUtc;
        itemToUpdate.DueDateUtc = entity.DueDateUtc;
        itemToUpdate.Status = entity.Status;
        itemToUpdate.Subtotal = entity.Subtotal;
        itemToUpdate.TaxRate = entity.TaxRate;
        itemToUpdate.TaxAmount = entity.TaxAmount;
        itemToUpdate.Total = entity.Total;
        itemToUpdate.Lines = entity.Lines;

        dbContext.Invoices.Update(itemToUpdate);
        await dbContext.SaveChangesAsync();
    }

    public async Task DeleteInvoiceAsync(int id)
    {
        var itemToDelete = await dbContext.Invoices.FindAsync(id)
            ?? throw new NotFoundException($"Item with {id} was not found");

        dbContext.Invoices.Remove(itemToDelete);
        await dbContext.SaveChangesAsync();
    }
}
