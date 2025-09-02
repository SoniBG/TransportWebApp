using Common.Enums;

namespace Common.Models;

public class VehicleDto
{
    public int Id { get; set; }

    public string PlateNumber { get; set; } = string.Empty;

    public VehicleType Type { get; set; } = VehicleType.Truck;

    public double? CapacityKg { get; set; }

    public double? VolumeM3 { get; set; }

    public string? Make { get; set; }

    public string? Model { get; set; }

    public int? Year { get; set; }

    public bool IsActive { get; set; }
}
