namespace BlazorServer.Data.Models.DTOs;

public class GuestChildDTO
{
    public int Id { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public int? GenderId { get; set; }
    public DateTime? DateOfBirth { get; set; }
    public bool EsolEnrolmentAtIwCollege { get; set; }
    public bool SchoolPlace { get; set; }
    public string? NameOfSchool { get; set; }
    public int? SchoolYearStartedSchool { get; set; }
    public string? HomeToSchoolTransport { get; set; }
    public DateTime DateCreated { get; set; }
    public string CreatedBy { get; set; } = string.Empty;
}