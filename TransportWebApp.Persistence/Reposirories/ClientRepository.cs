using Microsoft.EntityFrameworkCore;
using TransportWebApp.Domain.Entities;
using TransportWebApp.Domain.Exceptions;
using TransportWebApp.Domain.Repositories;
using TransportWebApp.Persistence.Data;

namespace TransportWebApp.Persistence.Reposirories;

public class ClientRepository : IClientRepository
{
    private readonly ApplicationDbContext dbContext;

    public ClientRepository(ApplicationDbContext dbContext)
    {
        this.dbContext = dbContext;
    }

    public async Task<Client> GetClientAsync(int id)
    {
        var entity = await dbContext.Clients.AsNoTracking()
            .Include(c => c.BillingAddress)
            .Include(c => c.DefaultPickupAddress)
            .FirstOrDefaultAsync(c => c.Id == id) ?? throw new NotFoundException($"Item with {id} was not found");

        return entity;
    }

    public async Task<List<Client>> GetClientsAsync()
    {
        var entityList = await dbContext.Clients.AsNoTracking().ToListAsync();

        return entityList;
    }

    public async Task<int> CreateClientAsync(Client entity)
    {
        await dbContext.Clients.AddAsync(entity);
        await dbContext.SaveChangesAsync();

        return entity.Id;
    }

    public async Task UpdateClientAsync(Client entity)
    {
        var itemToUpdate = await dbContext.Clients.FindAsync(entity.Id);

        if (itemToUpdate == default)
        {
            throw new NotFoundException($"Item with Id {entity.Id} was not found");
        }

        itemToUpdate.Name = entity.Name;
        itemToUpdate.Bulstat = entity.Bulstat;
        itemToUpdate.VatNumber = entity.VatNumber;
        itemToUpdate.Email = entity.Email;
        itemToUpdate.Phone = entity.Phone;
        itemToUpdate.BillingAddress = entity.BillingAddress;
        itemToUpdate.DefaultPickupAddress = entity.DefaultPickupAddress;
        itemToUpdate.IsActive = entity.IsActive;

        dbContext.Clients.Update(itemToUpdate);
        await dbContext.SaveChangesAsync();
    }

    public async Task DeleteClientAsync(int id)
    {
        var itemToDelete = await dbContext.Clients.FindAsync(id) ?? throw new NotFoundException($"Item with {id} was not found");

        dbContext.Clients.Remove(itemToDelete);
        await dbContext.SaveChangesAsync();
    }
}
