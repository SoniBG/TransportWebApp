using Microsoft.EntityFrameworkCore;
using TransportWebApp.Domain.Entities;
using TransportWebApp.Domain.Exceptions;
using TransportWebApp.Domain.Repositories;
using TransportWebApp.Persistence.Data;

namespace TransportWebApp.Persistence.Reposirories;

public class OrderRepository : IOrderRepository
{
    private readonly ApplicationDbContext dbContext;

    public OrderRepository(ApplicationDbContext dbContext)
    {
        this.dbContext = dbContext;
    }

    public async Task<Order> GetOrderAsync(int id)
    {
        var entity = await dbContext.Orders.AsNoTracking()
            .Include(o => o.Client)
            .Include(o => o.Items)
            .Include(o => o.Deliveries)
                .ThenInclude(d => d.Driver)
            .Include(o => o.Deliveries)
                .ThenInclude(d => d.Vehicle)
            .FirstOrDefaultAsync(o => o.Id == id) ?? throw new NotFoundException($"Item with {id} was not found");

        return entity;
    }

    public async Task<List<Order>> GetOrdersAsync()
    {
        return await dbContext.Orders.AsNoTracking()
            .Include(o => o.Client)
            .ToListAsync();
    }

    public async Task<int> CreateOrderAsync(Order entity)
    {
        await dbContext.Orders.AddAsync(entity);
        await dbContext.SaveChangesAsync();
        return entity.Id;
    }

    public async Task UpdateOrderAsync(Order entity)
    {
        var itemToUpdate = await dbContext.Orders.FindAsync(entity.Id)
            ?? throw new NotFoundException($"Item with Id {entity.Id} was not found");

        itemToUpdate.OrderNumber = entity.OrderNumber;
        itemToUpdate.ClientId = entity.ClientId;
        itemToUpdate.CreatedAtUtc = entity.CreatedAtUtc;
        itemToUpdate.RequiredPickupUtc = entity.RequiredPickupUtc;
        itemToUpdate.RequiredDeliveryUtc = entity.RequiredDeliveryUtc;
        itemToUpdate.Status = entity.Status;
        itemToUpdate.PickupAddress = entity.PickupAddress;
        itemToUpdate.DeliveryAddress = entity.DeliveryAddress;
        itemToUpdate.Notes = entity.Notes;
        itemToUpdate.Items = entity.Items;
        itemToUpdate.Deliveries = entity.Deliveries;
        itemToUpdate.Invoice = entity.Invoice;

        dbContext.Orders.Update(itemToUpdate);
        await dbContext.SaveChangesAsync();
    }

    public async Task DeleteOrderAsync(int id)
    {
        var itemToDelete = await dbContext.Orders.FindAsync(id)
            ?? throw new NotFoundException($"Item with {id} was not found");

        dbContext.Orders.Remove(itemToDelete);
        await dbContext.SaveChangesAsync();
    }
}
