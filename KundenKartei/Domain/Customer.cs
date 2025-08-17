using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;

namespace KundenKartei.Domain;

public class Customer
{
    [Key]
    [MaxLength(100)]
    public string CustomerId { get; set; } = Guid.NewGuid().ToString();

    [MaxLength(100)]
    public string? Title { get; set; }

    [MaxLength(100)]
    public string? TitleAfter { get; set; }

    [MaxLength(100)]
    public string? Name { get; set; }

    [MaxLength(100)]
    public string? FirstName { get; set; }

    public Address? Address { get; set; }

    public Contact? Contact { get; set; }

    public List<EventParticipant>? Participates { get; set; } = [];

    public List<ProductSale>? BoughtItems { get; set; }

    [IgnoreDataMember] 
    public string NameLabel => $"{Name} {FirstName}";

    [IgnoreDataMember] 
    public string EmailLabel => $"{Contact?.Email}";
    
    [IgnoreDataMember] 
    public string PhoneLabel => $"{Contact?.Phone}";
    
    [IgnoreDataMember]
    public string EventEarnings => GetEventEarnings();
    
    [IgnoreDataMember]
    public string SalesEarnings => GetSalesEarnings();
    
    private string GetEventEarnings()
    {
        decimal earnings = Participates?.Sum(x => x.Price) ?? 0;
        return $"{earnings:F2} €";
    }
    
    private string GetSalesEarnings()
    {
        decimal earnings = BoughtItems?.Sum(x => x.Price) ?? 0;
        return $"{earnings:F2} €";
    }
    
}