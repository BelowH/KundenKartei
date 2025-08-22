using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using Avalonia;
using Avalonia.Threading;
using KundenKartei.Domain;
using KundenKartei.Services;
using KundenKartei.State;
using Microsoft.Extensions.DependencyInjection;

namespace KundenKartei.ViewModel;

public class CustomerSearchControlViewModel : ViewModelBase
{

   private ICustomerService _customerService;
   
   private GlobalDisplayState _globalDisplayState;
   
   public string? SearchText { get; set; }
   
   public ObservableCollection<Customer> Customers { get; set; } = new();

   private List<Customer> _customers = [];
   
   public CustomerSearchControlViewModel()
   {
      
      IServiceProvider? serviceProvider = ((App)Application.Current!).ServiceProvider;
      
      _customerService = serviceProvider!.GetRequiredService<ICustomerService>();
      _globalDisplayState = serviceProvider!.GetRequiredService<GlobalDisplayState>();
      Task.Run(async () =>
      {
         List<Customer> customers = await _customerService.GetAllCustomers();
         Dispatcher.UIThread.Invoke(() =>
         {
            foreach (Customer customer in customers)
            {
               _customers.Add(customer);
               Customers.Add(customer);
            }
         });
      });
      
      
      Customer customer1 = new Customer()
      {
         FirstName = "Christoph",
         Name = "Belohaubek",
         Contact = new Contact(){Email = "christophbelohaubek@gmail.com", Phone = "+43 677 63157707"},
      };
      _customers.Add(customer1);
      Customer customer2 = new Customer()
      {
         FirstName = "Hans",
         Name = "Huber",
         Contact = new Contact() { Email = "h.huber@gmail.com", Phone = "+43 677 12345678" },
      };
      _customers.Add(customer2);

      Customers.Add(customer1);
      Customers.Add(customer2);
   }
   
   public void SearchCustomer(string searchText)
   {
      List<Customer> matchingCustomers = _customers.Where(c => c.NameLabel.Contains(searchText) || c.EmailLabel.Contains(searchText) || c.PhoneLabel.Contains(searchText)).ToList();
      if (matchingCustomers.Count == 0)
      {
         Customers.Clear();
         foreach (Customer customer in _customers)
         {
            Customers.Add(customer);
         }
      }
      Customers.Clear();
      foreach (Customer customer in matchingCustomers)
      {
         Customers.Add(customer);
      }
   }

   public void DeleteCustomer(string id)
   {
      Customer? customerToDelete = Customers.FirstOrDefault(c => c.CustomerId == id);
      if (customerToDelete != null)
      {
         Customers.Remove(customerToDelete);
         _customerService.DeleteCustomer(customerToDelete);
      }
   }
   
   public void NewCustomerPress()
   {
       _globalDisplayState.ChangeSubMask(EnumCollection.SubMask.NewCustomer);
   }
    
    
}