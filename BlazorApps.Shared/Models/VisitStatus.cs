namespace BlazorApps.Shared.Models;

public class VisitStatus
{
    public int Id { get; set; }
    public string Title { get; set; }
    
    public virtual ICollection<HomeVisitRecord> HomeVisitRecords { get; set; }
}