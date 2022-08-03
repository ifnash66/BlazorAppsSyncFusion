using BlazorServer.Data.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace BlazorServer.Data.Contexts;

public class AppDbContext: DbContext
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
    public virtual DbSet<AppUser> AppUsers => Set<AppUser>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<HostRecord>().ToTable(nameof(HostRecord));
        modelBuilder.Entity<GuestRecord>().ToTable(nameof(GuestRecord));
        modelBuilder.Entity<HomeVisitRecord>().ToTable(nameof(HomeVisitRecord));
        modelBuilder.Entity<VisitStatus>().ToTable(nameof(VisitStatus));
        modelBuilder.Entity<CaseInvolvement>().ToTable(nameof(CaseInvolvement));
        modelBuilder.Entity<CaseRecord>().ToTable(nameof(CaseRecord));
        modelBuilder.Entity<AppUser>().ToTable(nameof(AppUser));
        
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

        base.OnModelCreating(modelBuilder);
    }
}