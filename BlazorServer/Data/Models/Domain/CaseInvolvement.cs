using System.ComponentModel.DataAnnotations;

namespace BlazorServer.Data.Models.Domain;

public class CaseInvolvement
{
    public int Id { get; set; }
    public int CaseRecordId { get; set; }
    public int? HostRecordId { get; set; }
    public int? GuestRecordId { get; set; }
    public int? AppUserId { get; set; }
    public bool IsActive { get; set; }
    public DateTime DateCreated { get; set; }
    public string CreatedBy { get; set; } = string.Empty;
    
    public CaseRecord? CaseRecord { get; set; }
    public HostRecord? HostRecord { get; set; }
    public GuestRecord? GuestRecord { get; set; }
    public AppUser? AppUser { get; set; }
}