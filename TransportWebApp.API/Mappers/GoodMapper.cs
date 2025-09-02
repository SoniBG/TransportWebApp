using AutoMapper;
using Common.Models;
using TransportWebApp.Domain.Entities;

namespace TransportWebApp.API.Mappers;

public class GoodMapper : ITypeConverter<GoodDto, Good>
{
    public Good Convert(GoodDto source, Good destination, ResolutionContext context)
    {
        return new Good()
        {
            Id = source.Id,
            Name = source.Name,
            Sku = source.Sku,
            Description = source.Description,
            WeightKg = source.WeightKg,
            VolumeM3 = source.VolumeM3,
            UnitPrice = source.UnitPrice
        };
    }
}
