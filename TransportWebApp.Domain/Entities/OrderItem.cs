using System.ComponentModel.DataAnnotations;

namespace TransportWebApp.Domain.Entities;

public class OrderItem
{
    public int Id { get; set; }

    public int OrderId { get; set; }

    public Order Order { get; set; } = null!;

    public int GoodId { get; set; }

    public Good Good { get; set; } = null!;

    [Range(0.0, double.MaxValue)]
    public double Quantity { get; set; }

    // Unit price captured at the time of ordering
    public decimal UnitPrice { get; set; }

    // Convenience total; you can recompute instead if you prefer
    public decimal LineTotal { get; set; }
}
