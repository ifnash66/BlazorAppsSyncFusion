
namespace BlazorServer.Data.Models.Domain;

public class Gender
{
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;
    
    public ICollection<GuestRecord> GuestRecords { get; set; }
}