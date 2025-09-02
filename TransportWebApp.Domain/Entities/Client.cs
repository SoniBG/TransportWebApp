using System.ComponentModel.DataAnnotations;

namespace TransportWebApp.Domain.Entities;

public class Client
{
    public int Id { get; set; }

    [Required, MaxLength(256)]
    public string Name { get; set; } = "";

    [MaxLength(32)] public string? Bulstat { get; set; }

    [MaxLength(32)] public string? VatNumber { get; set; }

    [MaxLength(256)] public string? Email { get; set; }

    [MaxLength(32)] public string? Phone { get; set; }

    public Address BillingAddress { get; set; } = new();

    public Address DefaultPickupAddress { get; set; } = new();

    public bool IsActive { get; set; } = true;

    public DateTime CreatedAtUtc { get; set; } = DateTime.UtcNow;

    public ICollection<Order> Orders { get; set; } = new List<Order>();

    public ICollection<Invoice> Invoices { get; set; } = new List<Invoice>();
}
