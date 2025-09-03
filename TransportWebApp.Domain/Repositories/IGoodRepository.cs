using TransportWebApp.Domain.Entities;

namespace TransportWebApp.Domain.Repositories;

public interface IGoodRepository
{
    Task<Good> GetGoodAsync(int id);

    Task<List<Good>> GetGoodsAsync();

    Task<int> CreateGoodAsync(Good entity);

    Task UpdateGoodAsync(Good entity);

    Task DeleteGoodAsync(int id);
}
