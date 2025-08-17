using System.Collections.ObjectModel;
using KundenKartei.Domain;

namespace KundenKartei.ViewModel;

public class CustomerSearchControlViewModel : ViewModelBase
{

   public string? SearchText { get; set; }
   
   public ObservableCollection<Customer> Customers { get; set; } = new();
   
   public CustomerSearchControlViewModel()
   {
      Customer customer1 = new Customer()
      {
         FirstName = "Christoph",
         Name = "Belohaubek",
         Contact = new Contact(){Email = "christophbelohaubek@gmail.com", Phone = "+43 677 63157707"},
      };
      Customers.Add(customer1);
      Customer customer2 = new Customer()
      {
         FirstName = "Hans",
         Name = "Huber",
         Contact = new Contact() { Email = "h.huber@gmail.com", Phone = "+43 677 12345678" },
      };
      Customers.Add(customer2);

   }

   public void NewCustomerPress()
   {
       
   }
    
    
}