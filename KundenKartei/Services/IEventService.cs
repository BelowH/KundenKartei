using System.Collections.Generic;
using System.Threading.Tasks;
using KundenKartei.Domain;

namespace KundenKartei.Services;

public interface IEventService
{
    
    public Task<List<Event>> GetAllEvents();
    
    public Task<Event?> GetEventById(string id);
    
    public Task<Event> CreateEvent(Event item);
    
    public Task<Event> UpdateEvent(Event item);
    
    public Task DeleteEvent(Event item);
    
}