
using Microsoft.EntityFrameworkCore;
using TransportWebApp.Domain.Entities;
using TransportWebApp.Domain.Exceptions;
using TransportWebApp.Domain.Repositories;
using TransportWebApp.Persistence.Data;

namespace TransportWebApp.Persistence.Reposirories;

public class DeliveryRepository : IDeliveryRepository
{
    private readonly ApplicationDbContext dbContext;

    public DeliveryRepository(ApplicationDbContext dbContext)
    {
        this.dbContext = dbContext;
    }

    public async Task<Delivery> GetDeliveryAsync(int id)
    {
        var entity = await dbContext.Deliveries.AsNoTracking()
            .Include(d => d.Order)
            .Include(d => d.Driver)
            .Include(d => d.Vehicle)
            .FirstOrDefaultAsync(d => d.Id == id) ?? throw new NotFoundException($"Item with {id} was not found");

        return entity;
    }

    public async Task<List<Delivery>> GetDeliveriesAsync()
    {
        return await dbContext.Deliveries.AsNoTracking()
            .Include(d => d.Order)
            .Include(d => d.Driver)
            .Include(d => d.Vehicle)
            .ToListAsync();
    }

    public async Task<int> CreateDeliveryAsync(Delivery entity)
    {
        await dbContext.Deliveries.AddAsync(entity);
        await dbContext.SaveChangesAsync();
        return entity.Id;
    }

    public async Task UpdateDeliveryAsync(Delivery entity)
    {
        var itemToUpdate = await dbContext.Deliveries.FindAsync(entity.Id)
            ?? throw new NotFoundException($"Item with Id {entity.Id} was not found");

        itemToUpdate.OrderId = entity.OrderId;
        itemToUpdate.DriverId = entity.DriverId;
        itemToUpdate.VehicleId = entity.VehicleId;
        itemToUpdate.TrackingCode = entity.TrackingCode;
        itemToUpdate.ScheduledPickupUtc = entity.ScheduledPickupUtc;
        itemToUpdate.ActualPickupUtc = entity.ActualPickupUtc;
        itemToUpdate.ScheduledDropoffUtc = entity.ScheduledDropoffUtc;
        itemToUpdate.ActualDropoffUtc = entity.ActualDropoffUtc;
        itemToUpdate.Status = entity.Status;
        itemToUpdate.Notes = entity.Notes;

        dbContext.Deliveries.Update(itemToUpdate);
        await dbContext.SaveChangesAsync();
    }

    public async Task DeleteDeliveryAsync(int id)
    {
        var itemToDelete = await dbContext.Deliveries.FindAsync(id)
            ?? throw new NotFoundException($"Item with {id} was not found");

        dbContext.Deliveries.Remove(itemToDelete);
        await dbContext.SaveChangesAsync();
    }
}
