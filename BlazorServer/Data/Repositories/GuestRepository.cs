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
    
    public GuestRecord? GetGuest(int id)
    {
        using var context = _dbContextFactory.CreateDbContext();
        return context.GuestRecords.Find(id);
    }

    public void AddGuest(GuestRecord guest)
    {
        using var context = _dbContextFactory.CreateDbContext();
        context.GuestRecords.Add(guest);

        try
        {
            context.SaveChanges();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
        }
    }

    public void UpdateGuest(GuestRecord guest)
    {
        using var context = _dbContextFactory.CreateDbContext();
        context.Attach(guest);
        context.Entry(guest).State = EntityState.Modified;
        context.SaveChanges();
    }

    public void RemoveGuest(GuestRecord guest)
    {
        using var context = _dbContextFactory.CreateDbContext();
        context.GuestRecords.Remove(guest);
        context.SaveChanges();
    }

    public List<GuestRecord> GetGuests()
    {
        using var context = _dbContextFactory.CreateDbContext();
        return context.GuestRecords.ToList();
    }
    
    public List<Gender> GetGenderList()
    {
        using var context = _dbContextFactory.CreateDbContext();
        return context.Genders.ToList();
    }
}