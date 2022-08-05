using System.ComponentModel.DataAnnotations.Schema;

namespace BlazorServer.Data.Models.Domain;

public class AddressRecord
{
    public int Id { get; set; }
    public int HostRecordId { get; set; }
    public bool IsCurrentAddress { get; set; }
    public DateTime? MoveInDate { get; set; }
    public DateTime? MoveOutDate { get; set; }
    public string? BuildingNameNumber { get; set; }
    public string? Street { get; set; }
    public string? Town { get; set; }
    public string? County { get; set; }
    public string? Postcode { get; set; }
    
    public DateTime DateCreated { get; set; }
    public string CreatedBy { get; set; } = string.Empty;
    [NotMapped] public string AddressText => $"{BuildingNameNumber}, {Street}, {Town}, {County}, {Postcode}";
    public HostRecord? HostRecord { get; set; }
}