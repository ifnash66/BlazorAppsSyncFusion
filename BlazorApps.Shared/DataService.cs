using BlazorApps.Shared.Models;
using Microsoft.EntityFrameworkCore;

namespace BlazorApps.Shared;

public class DataService
{
    private readonly IDbContextFactory<AppDbContext> _dbContextFactory;

    public DataService(IDbContextFactory<AppDbContext> dbContextFactory)
    {
        _dbContextFactory = dbContextFactory;
    }

    public async Task<HostRecord?> GetHost(int id)
    {
        await using var context = await _dbContextFactory.CreateDbContextAsync();
        return await context.HostRecords.FindAsync(id);
    }

    public async Task AddHost(HostRecord host)
    {
        await using var context = await _dbContextFactory.CreateDbContextAsync();
        await context.HostRecords.AddAsync(host);
        await context.SaveChangesAsync();
    }

    public async Task UpdateHost(HostRecord host)
    {
        await using var context = await _dbContextFactory.CreateDbContextAsync();
        context.Attach(host);
        context.Entry(host).State = EntityState.Modified;
        await context.SaveChangesAsync();
    }

    public async Task RemoveHost(HostRecord host)
    {
        await using var context = await _dbContextFactory.CreateDbContextAsync();
        context.HostRecords.Remove(host);
        await context.SaveChangesAsync();
    }

    public async Task<List<HostRecord>> GetHosts()
    {
        await using var context = await _dbContextFactory.CreateDbContextAsync();
        return await context.HostRecords.ToListAsync();
    }

    public async Task<GuestRecord?> GetGuest(int id)
    {
        await using var context = await _dbContextFactory.CreateDbContextAsync();
        return await context.GuestRecords.FindAsync(id);
    }

    public async Task AddGuest(GuestRecord guest)
    {
        await using var context = await _dbContextFactory.CreateDbContextAsync();
        await context.GuestRecords.AddAsync(guest);

        try
        {
            await context.SaveChangesAsync();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
        }
    }

    public async Task UpdateGuest(GuestRecord guest)
    {
        await using var context = await _dbContextFactory.CreateDbContextAsync();
        context.Attach(guest);
        context.Entry(guest).State = EntityState.Modified;
        await context.SaveChangesAsync();
    }

    public async Task RemoveGuest(GuestRecord guest)
    {
        await using var context = await _dbContextFactory.CreateDbContextAsync();
        context.GuestRecords.Remove(guest);
        await context.SaveChangesAsync();
    }

    public async Task<List<GuestRecord>> GetGuests()
    {
        await using var context = await _dbContextFactory.CreateDbContextAsync();
        return await context.GuestRecords.ToListAsync();
    }

    public async Task<HomeVisitRecord?> GetHomeVisit(int id)
    {
        await using var context = await _dbContextFactory.CreateDbContextAsync();
        return await context.HomeVisitRecords.FindAsync(id);
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
        context.Attach(visit);
        context.Entry(visit).State = EntityState.Modified;
        await context.SaveChangesAsync();
    }

    public async Task<List<VisitStatus>> GetVisitStatusList()
    {
        await using var context = await _dbContextFactory.CreateDbContextAsync();
        return await context.VisitStatuses.ToListAsync();
    }

    public async Task<List<Gender>> GetGenderList()
    {
        await using var context = await _dbContextFactory.CreateDbContextAsync();
        return await context.Genders.ToListAsync();
    }

    public async Task RemoveHomeVisit(HomeVisitRecord visit)
    {
        await using var context = await _dbContextFactory.CreateDbContextAsync();
        context.HomeVisitRecords.Remove(visit);
        await context.SaveChangesAsync();
    }

    public async Task<List<HomeVisitRecord>> GetHomeVisits()
    {
        await using var context = await _dbContextFactory.CreateDbContextAsync();
        return await context.HomeVisitRecords.ToListAsync();
    }
}