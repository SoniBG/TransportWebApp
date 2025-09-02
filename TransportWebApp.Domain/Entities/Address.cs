using System.ComponentModel.DataAnnotations;

namespace TransportWebApp.Domain.Entities;

public class Address
{
    [MaxLength(128)] public string Country { get; set; } = "";
    [MaxLength(128)] public string City { get; set; } = "";
    [MaxLength(256)] public string Street { get; set; } = "";
    [MaxLength(32)] public string PostalCode { get; set; } = "";
}
