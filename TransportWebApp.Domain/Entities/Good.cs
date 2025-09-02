using System.ComponentModel.DataAnnotations;

namespace TransportWebApp.Domain.Entities;

public class Good
{
    public int Id { get; set; }

    [Required, MaxLength(128)]
    public string Name { get; set; } = "";

    [MaxLength(64)] public string? Sku { get; set; }

    [MaxLength(512)] public string? Description { get; set; }

    public double? WeightKg { get; set; }

    public double? VolumeM3 { get; set; }

    public decimal? UnitPrice { get; set; }
}
