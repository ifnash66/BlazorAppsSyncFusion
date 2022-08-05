using System.ComponentModel.DataAnnotations;

namespace BlazorServer.Data.Models.Domain;

public class CaseInvolvement
{
    public int Id { get; set; }
    public int CaseRecordId { get; set; }
    public int? HostRecordId { get; set; }
    public int? GuestRecordId { get; set; }
    
    public string? UserId { get; set; }
    public bool IsActive { get; set; }
    public DateTime DateCreated { get; set; }
    public string CreatedBy { get; set; } = string.Empty;
}