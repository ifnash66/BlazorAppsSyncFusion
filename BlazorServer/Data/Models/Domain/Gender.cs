
namespace BlazorServer.Data.Models.Domain;

public class Gender
{
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public DateTime DateCreated { get; set; }
    public string CreatedBy { get; set; } = string.Empty;
    
    public virtual ICollection<GuestRecord> GuestRecords { get; set; }
    public virtual ICollection<GuestChild> GuestChildren { get; set; }
}