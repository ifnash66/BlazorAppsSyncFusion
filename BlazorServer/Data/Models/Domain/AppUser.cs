using System.ComponentModel.DataAnnotations.Schema;

namespace BlazorServer.Data.Models.Domain;

public class AppUser: IdentityUser
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public bool IsValid { get; set; }

    [NotMapped] public string FullName => $"{FirstName} {LastName}";

}