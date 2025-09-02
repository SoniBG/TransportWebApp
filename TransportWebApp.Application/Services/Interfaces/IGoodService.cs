using Common.Models;

namespace TransportWebApp.Application.Services.Interfaces;

public interface IGoodService
{
    Task<GoodDto> GetGoodAsync(int id);

    Task<int> CreateGoodAsync(GoodDto model);

    Task UpdateGoodAsync(GoodDto model);

    Task DeleteGoodAsync(int id);
}
