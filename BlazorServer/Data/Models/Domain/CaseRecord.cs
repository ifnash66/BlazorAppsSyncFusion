using System.ComponentModel.DataAnnotations;

namespace BlazorServer.Data.Models.Domain;

public class CaseRecord
{
    public int Id { get; set; }
    public string? CaseReference { get; set; }
    public bool IsActive { get; set; }
    public DateTime DateCreated { get; set; }
    public string CreatedBy { get; set; } = string.Empty;
    
    public virtual ICollection<HomeVisitRecord> HomeVisitRecords { get; set; }
    public virtual ICollection<CaseNote> CaseNotes { get; set; }
}