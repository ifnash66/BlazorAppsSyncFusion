using System.ComponentModel.DataAnnotations;

namespace BlazorServer.Data.Models.Domain;

public class CaseRecord
{
    public int Id { get; set; }
    public string? CaseReference { get; set; }
    public bool IsActive { get; set; }
    public DateTime DateCreated { get; set; }
    
    public ICollection<CaseInvolvement> CaseInvolvements { get; set; }
    public ICollection<HomeVisitRecord> HomeVisitRecords { get; set; }
}