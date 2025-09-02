namespace Common.Models;

public class InvoiceLineDto
{
    public int Id { get; set; }

    public int InvoiceId { get; set; }

    public string Description { get; set; } = string.Empty;   // e.g. "Transport Sofia → Plovdiv"

    public double Quantity { get; set; }

    public decimal UnitPrice { get; set; }

    // Expose for reads; compute server-side as UnitPrice * (decimal)Quantity
    public decimal LineTotal { get; set; }
}
