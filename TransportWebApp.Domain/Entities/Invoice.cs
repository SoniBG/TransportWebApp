using Common.Enums;
using System.ComponentModel.DataAnnotations;

namespace TransportWebApp.Domain.Entities;

public class Invoice
{
    public int Id { get; set; }

    [Required, MaxLength(32)]
    public string InvoiceNumber { get; set; } = ""; // e.g., INV-2025-0001

    public int ClientId { get; set; }

    public Client Client { get; set; } = null!;

    // Optional tight link to a single order (1:1)
    public int OrderId { get; set; }

    public Order Order { get; set; } = null!;

    public DateTime IssueDateUtc { get; set; } = DateTime.UtcNow;

    public DateTime DueDateUtc { get; set; } = DateTime.UtcNow.AddDays(14);

    public InvoiceStatus Status { get; set; } = InvoiceStatus.Issued;

    public decimal Subtotal { get; set; }

    public decimal TaxRate { get; set; } // 0.2m for 20% VAT, for example

    public decimal TaxAmount { get; set; }

    public decimal Total { get; set; }

    public ICollection<InvoiceLine> Lines { get; set; } = new List<InvoiceLine>();
}
