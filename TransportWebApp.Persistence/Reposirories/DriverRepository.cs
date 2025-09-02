
using Microsoft.EntityFrameworkCore;
using TransportWebApp.Domain.Entities;
using TransportWebApp.Domain.Exceptions;
using TransportWebApp.Domain.Repositories;
using TransportWebApp.Persistence.Data;

namespace TransportWebApp.Persistence.Reposirories;

public class DriverRepository : IDriverRepository
{
    private readonly ApplicationDbContext dbContext;

    public DriverRepository(ApplicationDbContext dbContext)
    {
        this.dbContext = dbContext;
    }

    public async Task<Driver> GetDriverAsync(int id)
    {
        return await dbContext.Drivers.AsNoTracking()
            .FirstOrDefaultAsync(x => x.Id == id)
                ?? throw new NotFoundException($"Item with {id} was not found");
    }

    public async Task<List<Driver>> GetDriversAsync()
    {
        return await dbContext.Drivers.AsNoTracking().ToListAsync();
    }
        

    public async Task<int> CreateDriverAsync(Driver entity)
    {
        await dbContext.Drivers.AddAsync(entity);
        await dbContext.SaveChangesAsync();
        return entity.Id;
    }

    public async Task UpdateDriverAsync(Driver entity)
    {
        var itemToUpdate = await dbContext.Drivers.FindAsync(entity.Id)
            ?? throw new NotFoundException($"Item with Id {entity.Id} was not found");

        itemToUpdate.FirstName = entity.FirstName;
        itemToUpdate.LastName = entity.LastName;
        itemToUpdate.Email = entity.Email;
        itemToUpdate.Phone = entity.Phone;
        itemToUpdate.ApplicationUserId = entity.ApplicationUserId;
        itemToUpdate.IsActive = entity.IsActive;

        dbContext.Drivers.Update(itemToUpdate);
        await dbContext.SaveChangesAsync();
    }

    public async Task DeleteDriverAsync(int id)
    {
        var itemToDelete = await dbContext.Drivers.FindAsync(id)
            ?? throw new NotFoundException($"Item with {id} was not found");

        dbContext.Drivers.Remove(itemToDelete);
        await dbContext.SaveChangesAsync();
    }
}
