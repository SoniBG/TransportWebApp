using Common.Enums;
using System.ComponentModel.DataAnnotations;

namespace TransportWebApp.Domain.Entities;

public class Vehicle
{
    public int Id { get; set; }

    [Required, MaxLength(16)]
    public string PlateNumber { get; set; } = string.Empty;

    public VehicleType Type { get; set; } = VehicleType.Truck;

    public double? CapacityKg { get; set; }

    public double? VolumeM3 { get; set; }

    [MaxLength(64)] public string? Make { get; set; }

    [MaxLength(64)] public string? Model { get; set; }

    public int? Year { get; set; }

    public bool IsActive { get; set; } = true;

    public ICollection<Delivery> Deliveries { get; set; } = new List<Delivery>();
}
