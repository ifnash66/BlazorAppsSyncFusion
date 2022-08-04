using System.ComponentModel.DataAnnotations;

namespace BlazorServer.Data.Models.Domain;

public class CaseRecordDTO
{
    public int Id { get; set; }
    
    [Required]
    public string? CaseReference { get; set; }
    public bool IsActive { get; set; }
    public DateTime DateCreated { get; set; }
    public string CreatedBy { get; set; } = string.Empty;
    
}