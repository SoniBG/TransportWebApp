namespace Common.Models;

public class GoodDto
{
    public int Id { get; set; }

    public string Name { get; set; } = string.Empty;

    public string? Sku { get; set; }

    public string? Description { get; set; }

    public double? WeightKg { get; set; }

    public double? VolumeM3 { get; set; }

    public decimal? UnitPrice { get; set; }
}
