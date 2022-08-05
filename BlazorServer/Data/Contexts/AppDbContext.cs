using BlazorServer.Data.Models.Domain;
using BlazorServer.Data.Repositories;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
#nullable disable
namespace BlazorServer.Data.Contexts;

public class AppDbContext: IdentityDbContext
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
    public virtual DbSet<GuestGuestChild> GuestGuestChildren => Set<GuestGuestChild>();
    public virtual DbSet<AddressRecord> AddressRecords => Set<AddressRecord>();

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
        modelBuilder.Entity<GuestGuestChild>().ToTable(nameof(GuestGuestChild));
        modelBuilder.Entity<AddressRecord>().ToTable(nameof(AddressRecord));
        
        modelBuilder.Entity<VisitStatus>().HasData(new List<VisitStatus>
        {
            new VisitStatus { Id = 1, Title = "Scheduled"},
            new VisitStatus { Id = 2, Title = "In Progress"},
            new VisitStatus { Id = 3, Title = "Complete"}
        });
        
        modelBuilder.Entity<Gender>().HasData(new List<Gender>
        {
            new Gender { Id = 1, Title = "Male"},
            new Gender { Id = 2, Title = "Female"},
            new Gender { Id = 3, Title = "Other/not specified"}
        });
    }
}