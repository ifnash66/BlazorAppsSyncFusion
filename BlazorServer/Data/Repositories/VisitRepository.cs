using BlazorServer.Data.Contexts;
using BlazorServer.Data.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace BlazorServer.Data.Repositories;

public class VisitRepository
{
    private readonly IDbContextFactory<AppDbContext> _dbContextFactory;

    public VisitRepository(IDbContextFactory<AppDbContext> dbContextFactory)
    {
        _dbContextFactory = dbContextFactory;
    }

    public async Task<IEnumerable<HomeVisitRecord>> GetHomeVisits()
    {
        await using var context = await _dbContextFactory.CreateDbContextAsync();
        return await context.HomeVisitRecords.ToListAsync();
    }

    public async Task<IEnumerable<HomeVisitRecord>> GetHomeVisits(int caseId)
    {
        await using var context = await _dbContextFactory.CreateDbContextAsync();
        var visits = await context.HomeVisitRecords
            .Where(x => x.CaseRecordId == caseId).ToListAsync();
        return visits;
    }

    public async Task<HomeVisitRecord?> GetHomeVisit(int visitId)
    {
        await using var context = await _dbContextFactory.CreateDbContextAsync();
        return await context.HomeVisitRecords.FindAsync(visitId);
    }

    public async Task AddHomeVisit(HomeVisitRecord visit)
    {
        await using var context = await _dbContextFactory.CreateDbContextAsync();
        await context.HomeVisitRecords.AddAsync(visit);
        await context.SaveChangesAsync();
    }

    public async Task UpdateHomeVisit(HomeVisitRecord visit)
    {
        await using var context = await _dbContextFactory.CreateDbContextAsync();
        context.HomeVisitRecords.Update(visit);
        await context.SaveChangesAsync();
    }

    public async Task DeleteHomeVisit(int visitId)
    {
        await using var context = await _dbContextFactory.CreateDbContextAsync();
        var visit = await context.HomeVisitRecords.FindAsync(visitId);
        context.HomeVisitRecords.Remove(visit);
        await context.SaveChangesAsync();
    }
    
    public async Task<IEnumerable<VisitStatus>> GetVisitStatusList()
    {
        await using var context = await _dbContextFactory.CreateDbContextAsync();
        return await context.VisitStatuses.ToListAsync();
    }
}