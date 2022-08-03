using BlazorServer.Data.Contexts;
using BlazorServer.Data.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace BlazorServer.Data.Repositories;

public class HomeVisitRepository
{
    private readonly IDbContextFactory<AppDbContext> _dbContextFactory;

    public HomeVisitRepository(IDbContextFactory<AppDbContext> dbContextFactory)
    {
        _dbContextFactory = dbContextFactory;
    }
    public HomeVisitRecord GetHomeVisit(int id)
    {
        using var context = _dbContextFactory.CreateDbContext();
        return context.HomeVisitRecords.Find(id);
    }

    public void AddHomeVisit(HomeVisitRecord visit)
    {
        using var context = _dbContextFactory.CreateDbContext();
        context.HomeVisitRecords.Add(visit);
        context.SaveChanges();
    }

    public void UpdateHomeVisit(HomeVisitRecord visit)
    {
        using var context = _dbContextFactory.CreateDbContext();
        context.Attach(visit);
        context.Entry(visit).State = EntityState.Modified;
        context.SaveChanges();
    }

    public List<VisitStatus> GetVisitStatusList()
    {
        using var context = _dbContextFactory.CreateDbContext();
        return context.VisitStatuses.ToList();
    }

    public List<Gender> GetGenderList()
    {
        using var context = _dbContextFactory.CreateDbContext();
        return context.Genders.ToList();
    }

    public void RemoveHomeVisit(HomeVisitRecord visit)
    {
        using var context = _dbContextFactory.CreateDbContext();
        context.HomeVisitRecords.Remove(visit);
        context.SaveChanges();
    }

    public List<HomeVisitRecord> GetHomeVisits()
    {
        using var context = _dbContextFactory.CreateDbContext();
        return context.HomeVisitRecords.ToList();
    }
}