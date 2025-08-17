using System;
using System.ComponentModel.DataAnnotations;

namespace KundenKartei.Domain;

public class Address
{
    [Key]
    public string AddressId { get; set; } = Guid.NewGuid().ToString();

    public string? Name { get; set; }

    public string? Street { get; set; }

    public string? HouseNumber { get; set; }

    public string? City { get; set; }

    public string? ZipCode { get; set; }

    public string? County { get; set; }

    public string? Country { get; set; }
    
    public string EntityType { get; set; } // "Customer" or "Event"
    public string EntityId { get; set; }
    
}