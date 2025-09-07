using AutoMapper;
using Common.Models;
using TransportWebApp.Application.Services.Interfaces;
using TransportWebApp.Domain.Entities;
using TransportWebApp.Domain.Repositories;
using TransportWebApp.Persistence.Reposirories;

namespace TransportWebApp.Application.Services;

public class GoodService : IGoodService
{
    private readonly IGoodRepository goodRepository;
    private readonly IMapper mapper;

    public GoodService(IGoodRepository goodRepository, IMapper mapper)
    {
        this.goodRepository = goodRepository;
        this.mapper = mapper;
    }

    public async Task<GoodDto> GetGoodAsync(int id)
    {
        var entity = await goodRepository.GetGoodAsync(id);

        return mapper.Map<GoodDto>(entity);
    }

    public async Task<List<GoodDto>> GetGoodsAsync()
    {
        var entities = await goodRepository.GetGoodsAsync();
        return mapper.Map<List<GoodDto>>(entities);
    }

    public async Task<int> CreateGoodAsync(GoodDto model)
    {
        var entity = mapper.Map<Good>(model);

        return await goodRepository.CreateGoodAsync(entity);
    }

    public async Task DeleteGoodAsync(int id)
    {
        await goodRepository.DeleteGoodAsync(id);
    }

    public async Task UpdateGoodAsync(GoodDto model)
    {
        var entity = mapper.Map<Good>(model);

        await goodRepository.UpdateGoodAsync(entity);
    }
}
