using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KundenKartei.Database;
using KundenKartei.Domain;
using KundenKartei.Domain.DTO;
using Microsoft.EntityFrameworkCore;

namespace KundenKartei.Services;

public class CustomerService : ICustomerService
{
    
    private readonly AppDbContext _dbContext;

    public CustomerService(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }


    public async Task<List<SearchResult>> Search(string searchTerm)
    {
        List<SearchResult> result = await _dbContext.Customers
            .Where(c => $"{c.FirstName} {c.Name}".Contains(searchTerm))
            .Select(c => new SearchResult(c.CustomerId, $"{c.FirstName} {c.Name}", typeof(Customer))).ToListAsync();
        return result;
    }

    public async Task<List<Customer>> GetAllCustomers()
    {
        List<Customer> customers = await _dbContext.Customers.ToListAsync();
        return customers;
    }

    public async Task<Customer?> GetCustomerById(string id)
    {
        Customer? customer = await _dbContext.Customers.FirstOrDefaultAsync(c => c.CustomerId == id);
        return customer;
    }

    public async Task<List<Customer>> GetEventAttendees(string eventId)
    {
        List<Customer> customers = await _dbContext.Customers
            .Where(c => c.Participates != null && c.Participates
                .Any(p => p.EventId == eventId) == true)
            .ToListAsync();
        return customers;
    }

    public async Task<Customer> CreateCustomer(Customer customer)
    {
        _dbContext.Customers.Add(customer);
        await _dbContext.SaveChangesAsync();
        return customer;
    }

    public async Task<Customer> UpdateCustomer(Customer customer)
    {
        _dbContext.Customers.Update(customer);
        await _dbContext.SaveChangesAsync();
        return customer;
    }

    public async Task DeleteCustomer(Customer customer)
    {
        _dbContext.Customers.Remove(customer);
        await _dbContext.SaveChangesAsync();
    }
}