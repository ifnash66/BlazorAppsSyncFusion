using System.ComponentModel.DataAnnotations;

namespace BlazorServer.Data.Models.DTOs;

public class HomeVisitRecordDTO
{
    public int Id { get; set; }
    
    [Required]
    public int? VisitStatusId { get; set; }
    
    [Required]
    public DateTime? VisitDate { get; set; }
    
    public string? HostsVisited { get; set; }
    
    public string? GuestsVisited { get; set; }
    
    [Required]
    public string? VisitorName { get; set; }
    
    public bool IsTranslatorNeeded { get; set; }
    
    public string? TranslationLanguage { get; set; }
    public string? TranslatorName { get; set; }
    
    [Required]
    public string? VisitNotes { get; set; }
    public DateTime? DateCreated { get; set; }
    public string? CreatedBy { get; set; }
}