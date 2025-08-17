using System.Collections.Generic;
using System.Threading.Tasks;
using KundenKartei.Database;
using KundenKartei.Domain;
using Microsoft.EntityFrameworkCore;

namespace KundenKartei.Services;

public class EventService : IEventService
{
    
    private readonly AppDbContext _dbContext;

    public EventService(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    
    
    public async Task<List<Event>> GetAllEvents()
    {
        List<Event> events = await _dbContext.Events.ToListAsync();
        return events;
    }

    public async Task<Event?> GetEventById(string id)
    {
        Event? item = await _dbContext.Events.FirstOrDefaultAsync(e => e.EventId == id);
        return item;
    }

    public async Task<Event> CreateEvent(Event item)
    {
        _dbContext.Events.Add(item);
        await _dbContext.SaveChangesAsync();
        return item;
    }

    public async Task<Event> UpdateEvent(Event item)
    {
        _dbContext.Events.Update(item);
        await _dbContext.SaveChangesAsync();
        return item;
    }

    public async Task DeleteEvent(Event item)
    {
        _dbContext.Events.Remove(item);
        await _dbContext.SaveChangesAsync();
    }
}