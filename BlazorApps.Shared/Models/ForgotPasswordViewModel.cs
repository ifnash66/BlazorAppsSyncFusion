using System.ComponentModel.DataAnnotations;

namespace BlazorApps.Shared.Models;

public class ForgotPasswordViewModel
{
    [Required]
    [EmailAddress]
    public string Email { get; set; }
}