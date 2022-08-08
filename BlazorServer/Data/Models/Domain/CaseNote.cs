using Microsoft.CodeAnalysis.VisualBasic.Syntax;

namespace BlazorServer.Data.Models.Domain;

public class CaseNote
{
    public int Id { get; set; }
    public int CaseRecordId { get; set; }
    public int CaseNoteCategoryId { get; set; }
    public string NoteText { get; set; } = string.Empty;
    public DateTime DateCreated { get; set; }
    public string CreatedBy { get; set; } = string.Empty;
    public virtual CaseRecord CaseRecord { get; set; }
    public virtual CaseNoteCategory CaseNoteCategory { get; set; }
}