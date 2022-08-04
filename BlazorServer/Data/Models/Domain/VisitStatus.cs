namespace BlazorServer.Data.Models.Domain;

public class VisitStatus
{
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public DateTime DateCreated { get; set; }
    public string CreatedBy { get; set; } = string.Empty;
    
    public ICollection<HomeVisitRecord> HomeVisitRecords { get; set; }
}