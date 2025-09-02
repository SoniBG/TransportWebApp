namespace Common.Models;

public class ClientDto
{
    public int Id { get; set; }

    public string Name { get; set; } = "";

    public string? Bulstat { get; set; }

    public string? VatNumber { get; set; }

    public string? Email { get; set; }

    public string? Phone { get; set; }

    public AddressDto BillingAddress { get; set; } = new();

    public AddressDto DefaultPickupAddress { get; set; } = new();

    public bool IsActive { get; set; }

    public DateTime CreatedAtUtc { get; set; }
}
