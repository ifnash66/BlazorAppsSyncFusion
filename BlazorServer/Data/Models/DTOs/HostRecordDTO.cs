using System.ComponentModel.DataAnnotations;

namespace BlazorServer.Data.Models.DTOs;

public class HostRecordDTO: IValidatableObject
{
    public int Id { get; set; }
    [DataType(DataType.Date)] public DateTime? DataFromExport { get; set; }
    
    [Required]
    public string? FirstName { get; set; }
    
    [Required]
    public string? LastName { get; set; }
    public int HostAge { get; set; }
    
    [Required]
    public string? BuildingNameNumber { get; set; }
    
    [Required]
    public string? Street { get; set; }
    
    [Required]
    public string? Town { get; set; }
    public string? County { get; set; }
    
    [Required]
    public string? Postcode { get; set; }
    
    [Required]
    public string? InitialHomeVisit { get; set; }
    public bool ProformaInvoiceGivenToHost { get; set; }
    public bool BankDetailsConfirmed { get; set; }
    public bool ProformaSignedByCaiw { get; set; }
    public DateTime? DateCreated { get; set; }
    public string? CreatedBy { get; set; }
    
    public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
    {
        if (ProformaInvoiceGivenToHost)
        {
            if (BankDetailsConfirmed == false)
            {
                yield return new ValidationResult(
                    "Bank details must be confirmed if Proforma invoice has been give to the host",
                    new string[] {nameof(BankDetailsConfirmed)});
            }
        }
    }
}