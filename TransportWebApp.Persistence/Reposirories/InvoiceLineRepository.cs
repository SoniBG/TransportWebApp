using Microsoft.EntityFrameworkCore;
using TransportWebApp.Domain.Entities;
using TransportWebApp.Domain.Exceptions;
using TransportWebApp.Domain.Repositories;
using TransportWebApp.Persistence.Data;

namespace TransportWebApp.Persistence.Reposirories;

public class InvoiceLineRepository : IInvoiceLineRepository
{
    private readonly ApplicationDbContext dbContext;

    public InvoiceLineRepository(ApplicationDbContext dbContext)
    {
        this.dbContext = dbContext;
    }

    public async Task<InvoiceLine> GetInvoiceLineAsync(int id)
    {
        var entity = await dbContext.InvoiceLines.AsNoTracking()
            .Include(l => l.Invoice)
            .FirstOrDefaultAsync(l => l.Id == id) ?? throw new NotFoundException($"Item with {id} was not found");

        return entity;
    }

    public async Task<List<InvoiceLine>> GetInvoiceLinesAsync()
    {
        return await dbContext.InvoiceLines.AsNoTracking()
            .Include(l => l.Invoice)
            .ToListAsync();
    }

    public async Task<int> CreateInvoiceLineAsync(InvoiceLine entity)
    {
        await dbContext.InvoiceLines.AddAsync(entity);
        await dbContext.SaveChangesAsync();
        return entity.Id;
    }

    public async Task UpdateInvoiceLineAsync(InvoiceLine entity)
    {
        var itemToUpdate = await dbContext.InvoiceLines.FindAsync(entity.Id)
            ?? throw new NotFoundException($"Item with Id {entity.Id} was not found");

        itemToUpdate.InvoiceId = entity.InvoiceId;
        itemToUpdate.Description = entity.Description;
        itemToUpdate.Quantity = entity.Quantity;
        itemToUpdate.UnitPrice = entity.UnitPrice;
        itemToUpdate.LineTotal = entity.LineTotal;

        dbContext.InvoiceLines.Update(itemToUpdate);
        await dbContext.SaveChangesAsync();
    }

    public async Task DeleteInvoiceLineAsync(int id)
    {
        var itemToDelete = await dbContext.InvoiceLines.FindAsync(id)
            ?? throw new NotFoundException($"Item with {id} was not found");

        dbContext.InvoiceLines.Remove(itemToDelete);
        await dbContext.SaveChangesAsync();
    }
}
