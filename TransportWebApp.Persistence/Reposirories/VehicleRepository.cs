using Microsoft.EntityFrameworkCore;
using TransportWebApp.Domain.Entities;
using TransportWebApp.Domain.Exceptions;
using TransportWebApp.Domain.Repositories;
using TransportWebApp.Persistence.Data;

namespace TransportWebApp.Persistence.Reposirories;

public class VehicleRepository : IVehicleRepository
{
    private readonly ApplicationDbContext dbContext;

    public VehicleRepository(ApplicationDbContext dbContext)
    {
        this.dbContext = dbContext;
    }

    public async Task<Vehicle> GetVehicleAsync(int id)
    {
        return await dbContext.Vehicles.AsNoTracking()
            .FirstOrDefaultAsync(c => c.Id == id) ?? throw new NotFoundException($"Item with {id} was not found");
    }

    public async Task<List<Vehicle>> GetVehiclesAsync() 
    {
        return await dbContext.Vehicles.AsNoTracking().ToListAsync();
    }

    public async Task<int> CreateVehicleAsync(Vehicle entity)
    {
        await dbContext.Vehicles.AddAsync(entity);
        await dbContext.SaveChangesAsync();
        return entity.Id;
    }

    public async Task UpdateVehicleAsync(Vehicle entity)
    {
        var itemToUpdate = await dbContext.Vehicles.FindAsync(entity.Id)
            ?? throw new NotFoundException($"Item with Id {entity.Id} was not found");

        itemToUpdate.PlateNumber = entity.PlateNumber;
        itemToUpdate.Type = entity.Type;
        itemToUpdate.CapacityKg = entity.CapacityKg;
        itemToUpdate.VolumeM3 = entity.VolumeM3;
        itemToUpdate.Make = entity.Make;
        itemToUpdate.Model = entity.Model;
        itemToUpdate.Year = entity.Year;
        itemToUpdate.IsActive = entity.IsActive;

        dbContext.Vehicles.Update(itemToUpdate);
        await dbContext.SaveChangesAsync();
    }

    public async Task DeleteVehicleAsync(int id)
    {
        var itemToDelete = await dbContext.Vehicles.FindAsync(id)
            ?? throw new NotFoundException($"Item with {id} was not found");

        dbContext.Vehicles.Remove(itemToDelete);
        await dbContext.SaveChangesAsync();
    }
}
