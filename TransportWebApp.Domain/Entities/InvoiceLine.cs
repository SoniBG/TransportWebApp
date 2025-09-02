using System.ComponentModel.DataAnnotations;

namespace TransportWebApp.Domain.Entities;

public class InvoiceLine
{
    public int Id { get; set; }

    public int InvoiceId { get; set; }

    public Invoice Invoice { get; set; } = null!;

    [Required, MaxLength(256)]
    public string Description { get; set; } = ""; // e.g., "Transport Sofia → Plovdiv"

    public double Quantity { get; set; }

    public decimal UnitPrice { get; set; }

    public decimal LineTotal { get; set; }
}
