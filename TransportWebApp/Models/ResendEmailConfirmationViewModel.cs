using System.ComponentModel.DataAnnotations;

namespace TransportWebApp.Models;

public class ResendEmailConfirmationViewModel
{
    [Required]
    [EmailAddress]
    public string Email { get; set; } = "";
}
