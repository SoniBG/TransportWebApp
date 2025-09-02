namespace Common.Models;

public class DriverDto
{
    public int Id { get; set; }

    public string FirstName { get; set; } = string.Empty;

    public string LastName { get; set; } = string.Empty;

    public string FullName => $"{FirstName} {LastName}";

    public string? Email { get; set; }

    public string? Phone { get; set; }

    // Map drivers to Identity users
    public string? ApplicationUserId { get; set; }

    public bool IsActive { get; set; }
}
