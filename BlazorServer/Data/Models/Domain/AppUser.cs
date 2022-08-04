using System.ComponentModel.DataAnnotations.Schema;

namespace BlazorServer.Data.Models.Domain;

public class AppUser
{
    public int Id { get; set; }
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public bool IsValid { get; set; }
    
    public DateTime DateCreated { get; set; }
    public string CreatedBy { get; set; } = string.Empty;
    [NotMapped] public string FullName => $"{FirstName} {LastName}";
    
    public ICollection<CaseInvolvement> CaseInvolvements { get; set; }
}