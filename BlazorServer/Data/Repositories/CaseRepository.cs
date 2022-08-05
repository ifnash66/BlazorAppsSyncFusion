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

    public async Task<bool> HasInvolvementForCase(int caseRecordId, string userId)
    {
        await using var context = await _dbContextFactory.CreateDbContextAsync();
        var hasInvolvement = await context.CaseInvolvements
            .Where(x => x.CaseRecordId == caseRecordId && x.IsActive && x.UserId == userId)
            .AnyAsync();
        
        return hasInvolvement;
    }

    public async Task<IEnumerable<HostRecord>> GetInvolvedHosts(int caseRecordId)
    {
        await using var context = await _dbContextFactory.CreateDbContextAsync();
        var hostIds = await context.CaseInvolvements
            .Where(x => x.CaseRecordId == caseRecordId && x.IsActive)
            .Select(x => x.HostRecordId)
            .ToListAsync();
        
        var hostRecords = await context.HostRecords.Where(x => hostIds.Contains(x.Id)).ToListAsync();
        return hostRecords;
    }
    
    public async Task<IEnumerable<GuestRecord>> GetInvolvedGuests(int caseRecordId)
    {
        await using var context = await _dbContextFactory.CreateDbContextAsync();
        var guestIds = await context.CaseInvolvements
            .Where(x => x.CaseRecordId == caseRecordId && x.IsActive)
            .Select(x => x.GuestRecordId)
            .ToListAsync();

        var guestRecords = await context.GuestRecords.Where(x => guestIds.Contains(x.Id)).ToListAsync();
        return guestRecords;
    }
    
    public async Task<IEnumerable<IdentityUser>> GetInvolvedUsers(int caseRecordId)
    {
        await using var context = await _dbContextFactory.CreateDbContextAsync();
        var userIds = await context.CaseInvolvements
            .Where(x => x.CaseRecordId == caseRecordId && x.IsActive)
            .Select(x => x.UserId)
            .ToListAsync();

        var userRecords = await context.Users.Where(x => userIds.Contains(x.Id)).ToListAsync();
        return userRecords;
    }
    
    public async Task<IEnumerable<CaseRecord>> GetAssignedCases(string userId)
    {
        await using var context = await _dbContextFactory.CreateDbContextAsync();
        var involvedCaseRecordIds = await context.CaseInvolvements
            .Where(x => x.UserId == userId && x.IsActive)
            .Select(x => x.CaseRecordId)
            .ToListAsync();

        var caseRecords = await context.CaseRecords.Where(x => involvedCaseRecordIds.Contains(x.Id)).ToListAsync();
        return caseRecords;
    }
}