using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace KundenKartei.Domain;

public class User
{
    [Key]
    [MaxLength(100)]
    public string UserId { get; set; } = Guid.NewGuid().ToString();
    
    [MaxLength(100)]
    public string? Name { get; set; }

    public List<Event>? Events { get; set; }

    public List<ProductSale>? Sales { get; set; }
}