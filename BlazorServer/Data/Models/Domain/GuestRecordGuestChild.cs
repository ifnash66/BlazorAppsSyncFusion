namespace BlazorServer.Data.Models.Domain;

public class GuestRecordGuestChild
{
    public int Id { get; set; }
    public int GuestId { get; set; }
    public int GuestChildId { get; set; }
    public DateTime DateCreated { get; set; }
    public string CreatedBy { get; set; } = string.Empty;
    
    public virtual GuestChild GuestChild { get; set; }
    public virtual GuestRecord GuestRecord { get; set; }
}