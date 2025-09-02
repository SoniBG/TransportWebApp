using Common.Enums;
using System.ComponentModel.DataAnnotations;

namespace TransportWebApp.Domain.Entities;

public class Order
{
    public int Id { get; set; }

    [Required, MaxLength(32)]
    public string OrderNumber { get; set; } = ""; 

    public int ClientId { get; set; }

    public Client Client { get; set; } = null!;

    public DateTime CreatedAtUtc { get; set; } = DateTime.UtcNow;

    public DateTime? RequiredPickupUtc { get; set; }

    public DateTime? RequiredDeliveryUtc { get; set; }

    public OrderStatus Status { get; set; } = OrderStatus.Draft;

    public Address PickupAddress { get; set; } = new();

    public Address DeliveryAddress { get; set; } = new();

    [MaxLength(1000)] public string? Notes { get; set; }

    public ICollection<OrderItem> Items { get; set; } = new List<OrderItem>();

    public ICollection<Delivery> Deliveries { get; set; } = new List<Delivery>();

    public Invoice? Invoice { get; set; }
}
