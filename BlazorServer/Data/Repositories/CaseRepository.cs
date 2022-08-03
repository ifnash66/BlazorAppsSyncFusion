using BlazorServer.Data.Contexts;
using BlazorServer.Data.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace BlazorServer.Data.Repositories;

public class CaseRepository
{
    private readonly IDbContextFactory<AppDbContext> _dbContextFactory;

    public CaseRepository(IDbContextFactory<AppDbContext> dbContextFactory)
    {
        _dbContextFactory = dbContextFactory;
    }
    
    public CaseRecord? GetCase(int id)
    {
        using var context = _dbContextFactory.CreateDbContext();
        return context.CaseRecords.Find(id);
    }

    public void AddCase(CaseRecord caseRecord)
    {
        using var context = _dbContextFactory.CreateDbContext();
        context.CaseRecords.Add(caseRecord);

        try
        {
            context.SaveChanges();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
        }
    }

    public void UpdateCase(CaseRecord caseRecord)
    {
        using var context = _dbContextFactory.CreateDbContext();
        context.Attach(caseRecord);
        context.Entry(caseRecord).State = EntityState.Modified;
        context.SaveChanges();
    }

    public void RemoveCase(CaseRecord caseRecord)
    {
        using var context = _dbContextFactory.CreateDbContext();
        context.CaseRecords.Remove(caseRecord);
        context.SaveChanges();
    }

    public List<CaseRecord> GetCases()
    {
        using var context = _dbContextFactory.CreateDbContext();
        return context.CaseRecords.ToList();
    }
}