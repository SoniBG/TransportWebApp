using TransportWebApp.Domain.Entities;
using TransportWebApp.Domain.Exceptions;
using TransportWebApp.Domain.Repositories;
using TransportWebApp.Persistence.Data;

namespace TransportWebApp.Persistence.Reposirories;

public class GoodRepository : IGoodRepository
{
    private readonly ApplicationDbContext dbContext;

    public GoodRepository(ApplicationDbContext dbContext)
    {
        this.dbContext = dbContext;
    }

    public async Task<Good> GetGoodAsync(int id)
    {
        var entity = await dbContext.Goods.FindAsync(id) ?? throw new NotFoundException($"Item with {id} was not found");

        return entity;
    }

    public async Task<int> CreateGoodAsync(Good entity)
    {
        await dbContext.Goods.AddAsync(entity);
        await dbContext.SaveChangesAsync();

        return entity.Id;
    }

    public async Task UpdateGoodAsync(Good entity)
    {
        var itemToUpdate = await dbContext.Goods.FindAsync(entity.Id);

        if(itemToUpdate == default)
        {
            throw new NotFoundException($"Item with Id {entity.Id} was not found");
        }

        itemToUpdate.Name = entity.Name;
        itemToUpdate.Sku = entity.Sku;
        itemToUpdate.Description = entity.Description;
        itemToUpdate.WeightKg = entity.WeightKg;
        itemToUpdate.VolumeM3 = entity.VolumeM3;
        itemToUpdate.UnitPrice = entity.UnitPrice;

        dbContext.Goods.Update(itemToUpdate);
        await dbContext.SaveChangesAsync();
    }

    public async Task DeleteGoodAsync(int id)
    {
        var itemToDelete = await dbContext.Goods.FindAsync(id) ?? throw new NotFoundException($"Item with {id} was not found");

        dbContext.Goods.Remove(itemToDelete);
        await dbContext.SaveChangesAsync();
    }
}
