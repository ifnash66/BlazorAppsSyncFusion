using System.ComponentModel.DataAnnotations;

namespace BlazorApps.Shared.Models;

public class GuestRecordDTO : IValidatableObject
{
    public int Id { get; set; }

    // Personal details
    [Required]
    public string? FirstName { get; set; }
    
    [Required]
    public string? LastName { get; set; }
    
    [Required]
    [EmailAddress]
    public string? EmailAddress { get; set; }
    
    [Required]
    public string? PhoneNumber { get; set; }
    
    [Required]
    [DataType(DataType.Date)] public DateTime? DateOfBirth { get; set; }
    public int Age { get; set; }
    
    [Required]
    public int GenderId { get; set; }
    
    public int FamilyNumber { get; set; }
    public int NumberOfChildrenArrived { get; set; }
    public int NumberOfAdultsArrived { get; set; }
    
    [Required]
    [DataType(DataType.Date)] public DateTime? DateOfArrivalUk { get; set; }
    
    [Required]
    [DataType(DataType.Date)] public DateTime? DateOfArrivalAtAddress { get; set; }
    
    public decimal CashAllowance { get; set; }

    // Applications.
    public bool VodafoneSimGiven { get; set; }
    public bool NiApplicationMade { get; set; }
    public bool UcRegistration { get; set; }
    public bool UcApplicationMade { get; set; }
    public bool PensionCredit { get; set; }
    public bool BusAppDownloadedToPhone { get; set; }
    public bool GpApplicationSubmitted { get; set; }

    public string? NameOfSurgery { get; set; }
    public bool EsolEnrolmentAtIwCollege { get; set; }
    public bool BiometricResidencePermitAppliedFor { get; set; }
    public bool BiometricResidencePermitReceived { get; set; }

    // Schools.
    public bool SchoolPlace { get; set; }
    public string? NameOfSchool { get; set; }
    public int SchoolYearStartedSchool { get; set; }
    public string? HomeToSchoolTransport { get; set; }

    // Permissions.
    public bool PermissionToShareDataWithOtherUkrainianArrivals { get; set; }
    public bool PermissionForCaiwToHold { get; set; }
    public bool PermissionToShareContactInformationWithFaithOrganisation { get; set; }
    public bool PermissionToShareEmailAddressWithSv { get; set; }
    
    [Required]
    public string? Notes { get; set; }
    public DateTime DateCreated { get; set; }
    public string CreatedBy { get; set; } = string.Empty;

    public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
    {
        if (GpApplicationSubmitted)
        {
            if (string.IsNullOrWhiteSpace(NameOfSurgery))
            {
                yield return new ValidationResult("Name of surgery is required if a GP application has been made",
                    new string[] {nameof(NameOfSurgery)});
            }
        }
        if (Age > 17)
        {
            if (string.IsNullOrWhiteSpace(EmailAddress))
            {
                yield return new ValidationResult("Email address is required for adults",
                    new string[] {nameof(EmailAddress)});
            }

            if (string.IsNullOrWhiteSpace(PhoneNumber))
            {
                yield return new ValidationResult("Phone number is required for adults",
                    new string[] {nameof(EmailAddress)});
            }

            if (BusAppDownloadedToPhone == false)
            {
                yield return new ValidationResult("Bus app must be downloaded to phone for adult guests",
                    new string[] {nameof(BusAppDownloadedToPhone)});
            }

            if (UcRegistration == false)
            {
                yield return new ValidationResult("UC Registration must be true for adults",
                    new string[] {nameof(UcRegistration)});
            }

            if (UcApplicationMade == false)
            {
                yield return new ValidationResult("UC Application made must be true for adults",
                    new string[] {nameof(UcApplicationMade)});
            }
        }
        if (Age > 10)
        {
            if (VodafoneSimGiven == false)
            {
                yield return new ValidationResult("Vodafone SIM given is required for guests from the age of 11",
                    new string[] {nameof(VodafoneSimGiven)});
            }
        }
    }
}