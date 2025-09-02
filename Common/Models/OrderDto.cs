using Common.Enums;

namespace Common.Models;

public class OrderDto
{
    public int Id { get; set; }

    public string OrderNumber { get; set; } = string.Empty;

    public int ClientId { get; set; }

    public string? ClientName { get; set; } 

    public DateTime CreatedAtUtc { get; set; }

    public DateTime? RequiredPickupUtc { get; set; }

    public DateTime? RequiredDeliveryUtc { get; set; }

    public OrderStatus Status { get; set; }

    public AddressDto PickupAddress { get; set; } = new();

    public AddressDto DeliveryAddress { get; set; } = new();

    public string? Notes { get; set; }

    public List<OrderItemDto> Items { get; set; } = [];

    public List<DeliveryDto> Deliveries { get; set; } = [];

    public InvoiceDto? Invoice { get; set; }
}
