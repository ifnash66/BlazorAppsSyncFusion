namespace BlazorServer.Data.Models.Domain;

public class VisitStatus
{
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;
    
    public virtual ICollection<HomeVisitRecord> HomeVisitRecords { get; set; }
}