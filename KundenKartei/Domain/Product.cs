using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace KundenKartei.Domain;

public class Product
{
    [Key]    
    [MaxLength(100)]
    public string? ProductId { get; set; } = Guid.NewGuid().ToString();

    [MaxLength(100)]
    public string? Name { get; set; }

    public List<ProductSize>? Sizes { get; set; }

    public List<ProductColor>? Colors { get; set; }

    public decimal Price { get; set; }
    
    public List<ProductSale>? Sales { get; set; }
    
}