namespace BlazorApps.Shared.Models;

public class Gender
{
    public int Id { get; set; }
    public string Title { get; set; }
    
    public virtual ICollection<GuestRecord> GuestRecords { get; set; }
}