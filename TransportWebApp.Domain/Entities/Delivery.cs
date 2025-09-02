using Common.Enums;
using System.ComponentModel.DataAnnotations;

namespace TransportWebApp.Domain.Entities;

public class Delivery
{
    public int Id { get; set; }

    public int OrderId { get; set; }

    public Order Order { get; set; } = null!;

    public int? VehicleId { get; set; }

    public Vehicle? Vehicle { get; set; }

    public int? DriverId { get; set; }

    public Driver? Driver { get; set; }

    [MaxLength(64)] public string TrackingCode { get; set; } = Guid.NewGuid().ToString("N").ToUpper();

    public DateTime ScheduledPickupUtc { get; set; }

    public DateTime? ActualPickupUtc { get; set; }

    public DateTime ScheduledDropoffUtc { get; set; }

    public DateTime? ActualDropoffUtc { get; set; }

    public DeliveryStatus Status { get; set; } = DeliveryStatus.Scheduled;

    [MaxLength(1000)] public string? Notes { get; set; }
}
