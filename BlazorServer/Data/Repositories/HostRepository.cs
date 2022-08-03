using BlazorServer.Data.Contexts;
using BlazorServer.Data.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace BlazorServer.Data.Repositories;

public class HostRepository
{
    private readonly IDbContextFactory<AppDbContext> _dbContextFactory;

    public HostRepository(IDbContextFactory<AppDbContext> dbContextFactory)
    {
        _dbContextFactory = dbContextFactory;
    }

    public HostRecord? GetHost(int id)
    {
        using var context = _dbContextFactory.CreateDbContext();
        return context.HostRecords.Find(id);
    }

    public void AddHost(HostRecord host)
    {
        using var context = _dbContextFactory.CreateDbContext();
        context.HostRecords.Add(host);
        context.SaveChanges();
    }

    public void UpdateHost(HostRecord host)
    {
        using var context = _dbContextFactory.CreateDbContext();
        context.Attach(host);
        context.Entry(host).State = EntityState.Modified;
        context.SaveChanges();
    }

    public void RemoveHost(HostRecord host)
    {
        using var context = _dbContextFactory.CreateDbContext();
        context.HostRecords.Remove(host);
        context.SaveChanges();
    }

    public List<HostRecord> GetHosts()
    {
        using var context = _dbContextFactory.CreateDbContext();
        return context.HostRecords.ToList();
    }
}