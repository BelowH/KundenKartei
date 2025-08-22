using System;
using System.Threading.Tasks;
using Avalonia;
using Avalonia.Threading;
using KundenKartei.Domain;
using KundenKartei.Services;
using KundenKartei.State;
using Microsoft.Extensions.DependencyInjection;

namespace KundenKartei.ViewModel;

public class NewCustomerControlViewModel : ViewModelBase
{

    private readonly ICustomerService _customerService;
    
    private readonly GlobalDisplayState _globalDisplayState;
    
    private string _name;
    private bool _nameHasError;
    private string _firstname;
    private bool _firstnameHasError;
    
    private string _street;
    private string _houseNumber;
    private string _city;
    private string _zipCode;
    private string _country;

    private string _email;
    private bool _emailHasError;
    
    private string _phone;
    private string _mobile;
    private string _accountNumber;
    
    public string Name { get => _name; set => SetProperty(ref _name, value); }
    public bool NameHasError { get => _nameHasError; set => SetProperty(ref _nameHasError, value); }
    public string NameErrorMessage => "Bitte geben Sie einen Namen ein."; 
    public string Firstname { get => _firstname; set => SetProperty(ref _firstname, value); }
    public bool FirstnameHasError { get => _firstnameHasError; set => SetProperty(ref _firstnameHasError, value); }
    
    public string Street { get => _street; set => SetProperty(ref _street, value); }
    public string HouseNumber { get => _houseNumber; set => SetProperty(ref _houseNumber, value); }
    public string City { get => _city; set => SetProperty(ref _city, value); }
    public string ZipCode { get => _zipCode; set => SetProperty(ref _zipCode, value); }
    public string Country { get => _country; set => SetProperty(ref _country, value); }

    public string Email { get => _email; set => SetProperty(ref _email, value); }
    public bool EmailHasError { get => _emailHasError; set => SetProperty(ref _emailHasError, value); }
    public string EmailErrorMessage => "Bitte geben Sie eine korrekte E-Mail-Adresse ein.";
    public string Phone { get => _phone; set => SetProperty(ref _phone, value); }
    public string Mobile { get => _mobile; set => SetProperty(ref _mobile, value); }
    public string AccountNumber { get => _accountNumber; set => SetProperty(ref _accountNumber, value); }

    public NewCustomerControlViewModel()
    {
        
        IServiceProvider serviceProvider = ((App)Application.Current!).ServiceProvider!;
        _customerService = serviceProvider.GetRequiredService<ICustomerService>();
        _globalDisplayState = serviceProvider.GetRequiredService<GlobalDisplayState>();
    }

    public void CreateCustomer()
    {
        NameHasError = false;
        FirstnameHasError = false;
        EmailHasError = false;
        bool anyErrors = false;
        if (string.IsNullOrWhiteSpace(Name))
        {
            NameHasError = true;
            anyErrors = true;
        }

        if (string.IsNullOrWhiteSpace(Firstname))
        {
            FirstnameHasError = true;
            anyErrors = true;
        }
        if (string.IsNullOrWhiteSpace(Email) || !Email.Contains("@") || !Email.Contains("."))
        {
            EmailHasError = true;
            anyErrors = true;
        }

        if (anyErrors)
        {
            return;
        }

        try
        {
            Customer customer = new Customer()
            {
                Name = Name,
                FirstName = Firstname,
            };

            Address address = new Address()
            {
                Name = $"{Name} {Firstname}",
                Street = Street,
                HouseNumber = HouseNumber,
                City = City,
                ZipCode = ZipCode,
                Country = Country,
                EntityType = "Customer",
                EntityId = customer.CustomerId,
            };

            Contact contact = new Contact()
            {
                Phone = Phone,
                Mobile = Mobile,
                Email = Email,
                AccountNumber = AccountNumber
            };

            customer.Address = address;
            customer.Contact = contact;

            Task.Run(async () =>
            {
                await _customerService.CreateCustomer(customer);
                Dispatcher.UIThread.Invoke(() =>
                {
                    _globalDisplayState.NavigateToCustomerDetail(customer.CustomerId);
                });
            });
        }
        catch (Exception e)
        {
            // TODO: MESSAGE BOX WITH ERROR
        }
        
    }
    
    
}