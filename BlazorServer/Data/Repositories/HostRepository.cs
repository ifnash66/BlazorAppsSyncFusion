using BlazorServer.Data.Contexts;
using BlazorServer.Data.Models.Domain;
using BlazorServer.Migrations;
using Microsoft.EntityFrameworkCore;

namespace BlazorServer.Data.Repositories;

public class HostRepository
{
    private readonly IDbContextFactory<AppDbContext> _dbContextFactory;

    public HostRepository(IDbContextFactory<AppDbContext> dbContextFactory)
    {
        _dbContextFactory = dbContextFactory;
    }

    public async Task<IEnumerable<HostRecord>> GetHosts()
    {
        await using var context = await _dbContextFactory.CreateDbContextAsync();
        return await context.HostRecords.ToListAsync();
    }

    public async Task<IEnumerable<HostRecord>> GetHostsForCase(int caseId)
    {
        await using var context = await _dbContextFactory.CreateDbContextAsync();

        var hostIds = await context.CaseInvolvements.Where(x => x.CaseRecordId == caseId)
            .Select(x => x.HostRecordId).ToListAsync();
        var hostRecords = await context.HostRecords.Where(x => hostIds.Contains(x.Id)).ToListAsync();
        return hostRecords;
    }

    public async Task<HostRecord?> GetHost(int hostId)
    {
        await using var context = await _dbContextFactory.CreateDbContextAsync();
        return await context.HostRecords.FindAsync(hostId);
    }

    public async Task AddHost(HostRecord host)
    {
        await using var context = await _dbContextFactory.CreateDbContextAsync();
        await context.HostRecords.AddAsync(host);
        await context.SaveChangesAsync();

        var addressRecord = new AddressRecord
        {
            HostRecordId = host.Id,
            IsCurrentAddress = true,
            DateCreated = DateTime.Now,
            CreatedBy = "System",
            MoveInDate = DateTime.Now,
            BuildingNameNumber = host.BuildingNameNumber,
            Street = host.Street,
            Town = host.Town,
            County = host.County,
            Postcode = host.Postcode
        };

        await context.AddressRecords.AddAsync(addressRecord);
        await context.SaveChangesAsync();
    }

    public async Task UpdateHost(HostRecord host)
    {
        await using var context = await _dbContextFactory.CreateDbContextAsync();
        context.HostRecords.Update(host);
        await context.SaveChangesAsync();
    }

    public async Task DeleteHost(int hostId)
    {
        await using var context = await _dbContextFactory.CreateDbContextAsync();
        var hostRecord = await context.HostRecords.FindAsync(hostId);
        context.HostRecords.Remove(hostRecord);
        await context.SaveChangesAsync();
    }
    
    public async Task EndInvolvement(int caseId, int hostId)
    {
        await using var context = await _dbContextFactory.CreateDbContextAsync();
        var hostInvolvements = await context.CaseInvolvements
            .Where(x => x.CaseRecordId == caseId && x.HostRecordId == hostId && x.IsActive).ToListAsync();
        
        context.CaseInvolvements.RemoveRange(hostInvolvements);
        await context.SaveChangesAsync();
    }

    public async Task<IEnumerable<AddressRecord>> GetAddressHistory(int hostRecordId)
    {
        await using var context = await _dbContextFactory.CreateDbContextAsync();
        return await context.AddressRecords.Where(x => x.HostRecordId == hostRecordId).ToListAsync();
    }
    
    public async Task<AddressRecord> GetAddress(int addressRecordId)
    {
        await using var context = await _dbContextFactory.CreateDbContextAsync();
        return await context.AddressRecords.FindAsync(addressRecordId);
    }
    
    public async Task AddAddress(AddressRecord addressRecord)
    {
        await using var context = await _dbContextFactory.CreateDbContextAsync();
        await context.AddressRecords.AddAsync(addressRecord);
        await context.SaveChangesAsync();
    }
    
    public async Task UpdateAddress(AddressRecord addressRecord)
    {
        await using var context = await _dbContextFactory.CreateDbContextAsync();
        context.AddressRecords.Update(addressRecord);
        await context.SaveChangesAsync();
    }
    
    public async Task DeleteAddress(int addressRecordId)
    {
        await using var context = await _dbContextFactory.CreateDbContextAsync();
        var addressRecord = await context.AddressRecords.FindAsync(addressRecordId);
        context.AddressRecords.Remove(addressRecord);
        await context.SaveChangesAsync();
    }
}