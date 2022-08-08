using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BlazorServer.Data.Models.Domain;

public class HostRecord
{
    public int Id { get; set; }
    [DataType(DataType.Date)] public DateTime DataFromExport { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public DateTime? DateOfBirth { get; set; }
    public string? BuildingNameNumber { get; set; }
    public string? Street { get; set; }
    public string? Town { get; set; }
    public string? County { get; set; }
    public string? Postcode { get; set; }
    public string? InitialHomeVisit { get; set; }
    public bool ProformaInvoiceGivenToHost { get; set; }
    public bool BankDetailsConfirmed { get; set; }
    public bool ProformaSignedByCaiw { get; set; }
    public DateTime DateCreated { get; set; }
    public string CreatedBy { get; set; } = string.Empty;

    [NotMapped] public string FullName => $"{FirstName} {LastName}";
    [NotMapped] public string AddressText => $"{BuildingNameNumber}, {Street}, {Town}, {County}, {Postcode}";

    public virtual ICollection<AddressRecord> AddressRecords { get; set; }
}