using BlazorServer.Data.Models.Domain;
using BlazorServer.Data.Repositories;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
namespace BlazorServer.Data.Contexts;

public class AppDbContext: IdentityDbContext<AppUser>
{
    public AppDbContext(DbContextOptions<AppDbContext> options):base(options)
    {
            
    }

    public virtual DbSet<HostRecord> HostRecords => Set<HostRecord>();
    public virtual DbSet<GuestRecord> GuestRecords => Set<GuestRecord>();
    public virtual DbSet<HomeVisitRecord> HomeVisitRecords => Set<HomeVisitRecord>();
    public virtual DbSet<VisitStatus> VisitStatuses => Set<VisitStatus>();
    public virtual DbSet<Gender> Genders => Set<Gender>();
    public virtual DbSet<CaseRecord> CaseRecords => Set<CaseRecord>();
    public virtual DbSet<CaseInvolvement> CaseInvolvements => Set<CaseInvolvement>();
    public virtual DbSet<GuestChild> GuestChildren => Set<GuestChild>();
    public virtual DbSet<GuestRecordGuestChild> GuestGuestChildren => Set<GuestRecordGuestChild>();
    public virtual DbSet<AddressRecord> AddressRecords => Set<AddressRecord>();
    public virtual DbSet<CaseNote> CaseNotes => Set<CaseNote>();
    public virtual DbSet<CaseNoteCategory> CaseNoteCategories => Set<CaseNoteCategory>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        
        modelBuilder.Entity<HostRecord>().ToTable(nameof(HostRecord));
        modelBuilder.Entity<GuestRecord>().ToTable(nameof(GuestRecord));
        modelBuilder.Entity<HomeVisitRecord>().ToTable(nameof(HomeVisitRecord));
        modelBuilder.Entity<VisitStatus>().ToTable(nameof(VisitStatus));
        modelBuilder.Entity<CaseInvolvement>().ToTable(nameof(CaseInvolvement));
        modelBuilder.Entity<CaseRecord>().ToTable(nameof(CaseRecord));
        modelBuilder.Entity<GuestChild>().ToTable(nameof(GuestChild));
        modelBuilder.Entity<GuestRecordGuestChild>().ToTable(nameof(GuestRecordGuestChild));
        modelBuilder.Entity<AddressRecord>().ToTable(nameof(AddressRecord));
        modelBuilder.Entity<CaseNote>().ToTable(nameof(CaseNote));
        modelBuilder.Entity<CaseNoteCategory>().ToTable(nameof(CaseNoteCategory));
    }
}