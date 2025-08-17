using System.Collections.Generic;
using System.Threading.Tasks;
using KundenKartei.Domain;
using KundenKartei.Domain.DTO;

namespace KundenKartei.Services;

public interface ICustomerService
{
    
    public Task<List<SearchResult>> Search(string searchTerm);
    
    public Task<List<Customer>> GetAllCustomers();
    
    public Task<Customer?> GetCustomerById(string id);
    
    public Task<List<Customer>> GetEventAttendees(string eventId);
    
    public Task<Customer> CreateCustomer(Customer customer);
    
    public Task<Customer> UpdateCustomer(Customer customer);

    public Task DeleteCustomer(Customer customer);

}