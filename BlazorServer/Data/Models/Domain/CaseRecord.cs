using System.ComponentModel.DataAnnotations;

namespace BlazorServer.Data.Models.Domain;

public class CaseRecord
{
    public int Id { get; set; }
    
    [Required]
    public string CaseReference { get; set; } = string.Empty;
    
    public bool IsActive { get; set; }
    
    public DateTime DateCreated { get; set; }
    
    public virtual  ICollection<CaseInvolvement> CaseInvolvements { get; set; }
}