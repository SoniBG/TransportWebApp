using Common.Enums;

namespace Common.Models;

public class InvoiceDto
{
    public int Id { get; set; }

    public string InvoiceNumber { get; set; } = "";

    public int ClientId { get; set; }

    public string? ClientName { get; set; }         

    public int OrderId { get; set; }

    public string? OrderNumber { get; set; }         

    public DateTime IssueDateUtc { get; set; }

    public DateTime DueDateUtc { get; set; }

    public InvoiceStatus Status { get; set; }

    // Money fields — compute server-side
    public decimal Subtotal { get; set; }

    public decimal TaxRate { get; set; }             // e.g., 0.20m for 20% VAT

    public decimal TaxAmount { get; set; }

    public decimal Total { get; set; }

    public List<InvoiceLineDto> Lines { get; set; } = [];
}
