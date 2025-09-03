using Microsoft.EntityFrameworkCore;
using TransportWebApp.Domain.Entities;
using TransportWebApp.Domain.Exceptions;
using TransportWebApp.Domain.Repositories;
using TransportWebApp.Persistence.Data;

namespace TransportWebApp.Persistence.Reposirories;

public class OrderItemRepository : IOrderItemRepository
{
    private readonly ApplicationDbContext dbContext;

    public OrderItemRepository(ApplicationDbContext dbContext)
    {
        this.dbContext = dbContext;
    }

    public async Task<OrderItem> GetOrderItemAsync(int id)
    {
        var entity = await dbContext.OrderItems.AsNoTracking()
            .Include(oi => oi.Order)
            .Include(oi => oi.Good)
            .FirstOrDefaultAsync(oi => oi.Id == id) ?? throw new NotFoundException($"Item with {id} was not found");

        return entity;
    }

    public async Task<List<OrderItem>> GetOrderItemsAsync()
    {
        var entityList = await dbContext.OrderItems.AsNoTracking()
            .Include(oi => oi.Order)
            .Include(oi => oi.Good)
            .ToListAsync();

        return entityList;
    }

    public async Task<int> CreateOrderItemAsync(OrderItem entity)
    {
        await dbContext.OrderItems.AddAsync(entity);
        await dbContext.SaveChangesAsync();
        return entity.Id;
    }

    public async Task UpdateOrderItemAsync(OrderItem entity)
    {
        var itemToUpdate = await dbContext.OrderItems.FindAsync(entity.Id)
            ?? throw new NotFoundException($"Item with Id {entity.Id} was not found");

        itemToUpdate.OrderId = entity.OrderId;
        itemToUpdate.GoodId = entity.GoodId;
        itemToUpdate.Quantity = entity.Quantity;
        itemToUpdate.UnitPrice = entity.UnitPrice;
        itemToUpdate.LineTotal = entity.LineTotal;

        dbContext.OrderItems.Update(itemToUpdate);
        await dbContext.SaveChangesAsync();
    }

    public async Task DeleteOrderItemAsync(int id)
    {
        var itemToDelete = await dbContext.OrderItems.FindAsync(id)
            ?? throw new NotFoundException($"Item with {id} was not found");

        dbContext.OrderItems.Remove(itemToDelete);
        await dbContext.SaveChangesAsync();
    }
}
