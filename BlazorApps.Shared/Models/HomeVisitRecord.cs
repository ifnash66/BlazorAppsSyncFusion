namespace BlazorApps.Shared.Models;

public class HomeVisitRecord
{
    public int Id { get; set; }
    public int? VisitStatusId { get; set; }
    public DateTime? VisitDate { get; set; }
    public string? HostsVisited { get; set; }
    public string? GuestsVisited { get; set; }
    public string? VisitorName { get; set; }
    public bool IsTranslatorNeeded { get; set; }
    public string? TranslationLanguage { get; set; }
    public string? TranslatorName { get; set; }
    public string? VisitNotes { get; set; }
    public DateTime? DateCreated { get; set; }
    public string? CreatedBy { get; set; }
    
    public virtual VisitStatus? VisitStatus { get; set; }
}