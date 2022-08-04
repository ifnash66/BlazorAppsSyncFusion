using BlazorServer.Data.Contexts;
using BlazorServer.Data.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace BlazorServer.Data.Repositories;

public class GuestRepository
{
    private readonly IDbContextFactory<AppDbContext> _dbContextFactory;

    public GuestRepository(IDbContextFactory<AppDbContext> dbContextFactory)
    {
        _dbContextFactory = dbContextFactory;
    }

    public async Task<IEnumerable<GuestRecord>> GetGuests()
    {
        await using var context = await _dbContextFactory.CreateDbContextAsync();
        return await context.GuestRecords.ToListAsync();
    }

    public async Task<IEnumerable<GuestRecord>> GetGuestsForCase(int caseId)
    {
        await using var context = await _dbContextFactory.CreateDbContextAsync();

        var guestIds = await context.CaseInvolvements.Where(x => x.CaseRecordId == caseId)
            .Select(x => x.GuestRecordId).ToListAsync();
        var guestRecords = await context.GuestRecords.Where(x => guestIds.Contains(x.Id)).ToListAsync();
        return guestRecords;
    }

    public async Task<GuestRecord?> GetGuest(int guestId)
    {
        await using var context = await _dbContextFactory.CreateDbContextAsync();
        return await context.GuestRecords.FindAsync(guestId);
    }

    public async Task AddGuest(GuestRecord guest)
    {
        await using var context = await _dbContextFactory.CreateDbContextAsync();
        await context.GuestRecords.AddAsync(guest);
        await context.SaveChangesAsync();
    }

    public async Task UpdateGuest(GuestRecord guest)
    {
        await using var context = await _dbContextFactory.CreateDbContextAsync();
        context.GuestRecords.Update(guest);
        await context.SaveChangesAsync();
    }

    public async Task DeleteGuest(int guestId)
    {
        await using var context = await _dbContextFactory.CreateDbContextAsync();
        var guestRecord = await context.GuestRecords.FindAsync(guestId);
        context.GuestRecords.Remove(guestRecord);
        await context.SaveChangesAsync();
    }

    public async Task EndInvolvement(int caseId, int guestId)
    {
        await using var context = await _dbContextFactory.CreateDbContextAsync();
        var guestInvolvements = await context.CaseInvolvements
            .Where(x => x.CaseRecordId == caseId && x.GuestRecordId == guestId && x.IsActive).ToListAsync();
        
        context.CaseInvolvements.RemoveRange(guestInvolvements);
        await context.SaveChangesAsync();
    }
    
    public async Task<IEnumerable<Gender>> GetGenderList()
    {
        await using var context = await _dbContextFactory.CreateDbContextAsync();
        return await context.Genders.ToListAsync();
    }
}