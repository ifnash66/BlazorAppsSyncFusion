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

    public async Task<IEnumerable<CaseRecord>> GetCases()
    {
        await using var context = await _dbContextFactory.CreateDbContextAsync();
        return await context.CaseRecords.ToListAsync();
    }

    public async Task<CaseRecord?> GetCase(int caseId)
    {
        await using var context = await _dbContextFactory.CreateDbContextAsync();
        return await context.CaseRecords.FindAsync(caseId);
    }

    public async Task AddCase(CaseRecord caseRecord)
    {
        await using var context = await _dbContextFactory.CreateDbContextAsync();
        await context.CaseRecords.AddAsync(caseRecord);
        await context.SaveChangesAsync();
    }

    public async Task UpdateCase(CaseRecord caseRecord)
    {
        await using var context = await _dbContextFactory.CreateDbContextAsync();
        context.CaseRecords.Update(caseRecord);
        await context.SaveChangesAsync();
    }

    public async Task DeleteCase(int caseId)
    {
        await using var context = await _dbContextFactory.CreateDbContextAsync();
        var caseRecord = await context.CaseRecords.FindAsync(caseId);
        context.CaseRecords.Remove(caseRecord);
        await context.SaveChangesAsync();
    }
}