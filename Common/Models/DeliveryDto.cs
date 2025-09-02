using Common.Enums;

namespace Common.Models;

public class DeliveryDto
{
    public int Id { get; set; }

    public int OrderId { get; set; }

    public int? VehicleId { get; set; }

    public string? VehicleIdentifier { get; set; } // e.g. plate number

    public int? DriverId { get; set; }

    public string? DriverName { get; set; }

    public string TrackingCode { get; set; } = string.Empty;

    public DateTime ScheduledPickupUtc { get; set; }

    public DateTime? ActualPickupUtc { get; set; }

    public DateTime ScheduledDropoffUtc { get; set; }

    public DateTime? ActualDropoffUtc { get; set; }

    public DeliveryStatus Status { get; set; }

    public string? Notes { get; set; }
}
