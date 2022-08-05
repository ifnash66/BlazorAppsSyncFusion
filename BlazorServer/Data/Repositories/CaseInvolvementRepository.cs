using BlazorServer.Data.Contexts;
using BlazorServer.Data.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace BlazorServer.Data.Repositories;

public class CaseInvolvementRepository
{
    private readonly IDbContextFactory<AppDbContext> _dbContextFactory;

    public CaseInvolvementRepository(IDbContextFactory<AppDbContext> dbContextFactory)
    {
        _dbContextFactory = dbContextFactory;
    }

    public async Task<IEnumerable<CaseInvolvement>> GetCaseInvolvementsForCase(int caseId)
    {
        await using var context = await _dbContextFactory.CreateDbContextAsync();
        return await context.CaseInvolvements.Where(x => x.CaseRecordId == caseId).ToListAsync();
    }

    public async Task<CaseInvolvement?> GetCaseInvolvement(int caseInvolvementId)
    {
        await using var context = await _dbContextFactory.CreateDbContextAsync();
        return await context.CaseInvolvements.FindAsync(caseInvolvementId);
    }

    public async Task AddCaseInvolvement(CaseInvolvement caseInvolvement)
    {
        await using var context = await _dbContextFactory.CreateDbContextAsync();
        await context.CaseInvolvements.AddAsync(caseInvolvement);
        await context.SaveChangesAsync();
    }

    public async Task UpdateCaseInvolvement(CaseInvolvement caseInvolvement)
    {
        await using var context = await _dbContextFactory.CreateDbContextAsync();
        context.Attach(caseInvolvement);
        context.Entry(caseInvolvement).State = EntityState.Modified;
        await context.SaveChangesAsync();
    }

    public async Task DeleteCaseInvolvement(int caseInvolvementId)
    {
        await using var context = await _dbContextFactory.CreateDbContextAsync();
        var caseInvolvement = await context.CaseInvolvements.FindAsync(caseInvolvementId);
        context.CaseInvolvements.Remove(caseInvolvement);
        await context.SaveChangesAsync();
    }
}