using BlazorServer.Data.Contexts;
using BlazorServer.Data.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace BlazorServer.Data.Repositories;

public class CaseNoteRepository
{
    private readonly IDbContextFactory<AppDbContext> _dbContextFactory;

    public CaseNoteRepository(IDbContextFactory<AppDbContext> dbContextFactory)
    {
        _dbContextFactory = dbContextFactory;
    }

    public async Task<IEnumerable<CaseNote>> GetCaseNotes()
    {
        await using var context = await _dbContextFactory.CreateDbContextAsync();
        return await context.CaseNotes.Include(x => x.CaseNoteCategory).ToListAsync();
    }

    public async Task<CaseNote?> GetCaseNote(int caseNoteId)
    {
        await using var context = await _dbContextFactory.CreateDbContextAsync();
        return await context.CaseNotes.FindAsync(caseNoteId);
    }

    public async Task AddCaseNote(CaseNote caseNote)
    {
        await using var context = await _dbContextFactory.CreateDbContextAsync();
        await context.CaseNotes.AddAsync(caseNote);
        await context.SaveChangesAsync();
    }

    public async Task UpdateCaseNote(CaseNote caseNote)
    {
        await using var context = await _dbContextFactory.CreateDbContextAsync();
        context.Attach(caseNote);
        context.Entry(caseNote).State = EntityState.Modified;
        await context.SaveChangesAsync();
    }

    public async Task DeleteCaseNote(int caseNoteId)
    {
        await using var context = await _dbContextFactory.CreateDbContextAsync();
        var caseNote = await context.CaseNotes.FindAsync(caseNoteId);
        context.CaseNotes.Remove(caseNote);
        await context.SaveChangesAsync();
    }
    
    public async Task<IEnumerable<CaseNoteCategory>> GetCaseNoteCategoryList()
    {
        await using var context = await _dbContextFactory.CreateDbContextAsync();
        return await context.CaseNoteCategories.ToListAsync();
    }
}