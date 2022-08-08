namespace BlazorServer.Data.Models.Domain;

public class CaseNoteCategory
{
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public DateTime DateCreated { get; set; }
    public string CreatedBy { get; set; } = string.Empty;
    public virtual ICollection<CaseNote> CaseNotes { get; set; }
}