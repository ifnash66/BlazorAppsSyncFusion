using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace BlazorServer.Data.Models.Domain;

public class GuestRecord
{
    public int Id { get; set; }
    // Personal details
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    
    [EmailAddress]
    public string? EmailAddress { get; set; }
    public string? PhoneNumber { get; set; }
    [DataType(DataType.Date)] public DateTime? DateOfBirth { get; set; }
    public int? Age { get; set; }
    public int? GenderId { get; set; }
    public int? FamilyNumber { get; set; }
    public int? NumberOfChildrenArrived { get; set; }
    public int? NumberOfAdultsArrived { get; set; }
    [DataType(DataType.Date)] public DateTime? DateOfArrivalUk { get; set; }
    [DataType(DataType.Date)] public DateTime? DateOfArrivalAtAddress { get; set; }
    public decimal? CashAllowance { get; set; }

    // Applications.
    public bool VodafoneSimGiven { get; set; }
    public bool NiApplicationMade { get; set; }
    public bool UcRegistration { get; set; }
    public bool UcApplicationMade { get; set; }
    public bool PensionCredit { get; set; }
    public bool BusAppDownloadedToPhone { get; set; }
    public bool GpApplicationSubmitted { get; set; }

    public string? NameOfSurgery { get; set; }
    public bool BiometricResidencePermitAppliedFor { get; set; }
    public bool BiometricResidencePermitReceived { get; set; }

    // Permissions.
    public bool PermissionToShareDataWithOtherUkrainianArrivals { get; set; }
    public bool PermissionForCaiwToHold { get; set; }
    public bool PermissionToShareContactInformationWithFaithOrganisation { get; set; }
    public bool PermissionToShareEmailAddressWithSv { get; set; }
    public string? Notes { get; set; }
    public DateTime DateCreated { get; set; }
    public string CreatedBy { get; set; } = string.Empty;
    
    public Gender? Gender { get; set; }

    [NotMapped] public string FullName => $"{FirstName} {LastName}";
    
    public ICollection<GuestGuestChild> GuestGuestChildren { get; set; }

}