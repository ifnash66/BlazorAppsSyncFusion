using System.ComponentModel.DataAnnotations;

namespace BlazorServer.Data.Models.Domain;

public class CaseInvolvement
{
    public int Id { get; set; }
    public int? HostRecordId { get; set; }
    public int? GuestRecordId { get; set; }
    public int? AppUserId { get; set; }
    public bool IsActive { get; set; }
    
    [Required]
    public DateTime FromDate { get; set; }
    public DateTime? ToDate { get; set; }
    public DateTime DateCreated { get; set; }
    
    public virtual HostRecord? HostRecord { get; set; }
    public virtual GuestRecord? GuestRecord { get; set; }
    public virtual AppUser? AppUser { get; set; }
}