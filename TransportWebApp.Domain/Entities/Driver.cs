using System.ComponentModel.DataAnnotations;

namespace TransportWebApp.Domain.Entities;

public class Driver
{
    public int Id { get; set; }

    [Required, MaxLength(128)] public string FirstName { get; set; } = "";

    [Required, MaxLength(128)] public string LastName { get; set; } = "";

    [MaxLength(256)] public string? Email { get; set; }

    [MaxLength(32)] public string? Phone { get; set; }

    // If you later map drivers to Identity users, keep this optional FK
    public string? ApplicationUserId { get; set; }

    public bool IsActive { get; set; } = true;

    public ICollection<Delivery> Deliveries { get; set; } = new List<Delivery>();
}
