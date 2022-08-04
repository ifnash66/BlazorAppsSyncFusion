namespace BlazorServer.Data.Models.Domain;

public class GuestGuestChild
{
    public int Id { get; set; }
    public int GuestId { get; set; }
    public int GuestChildId { get; set; }
    public DateTime DateCreated { get; set; }
    public string CreatedBy { get; set; } = string.Empty;
    
    public GuestChild? GuestChild { get; set; }
    public GuestRecord? GuestRecord { get; set; }
}