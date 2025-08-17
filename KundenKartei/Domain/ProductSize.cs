using System;
using System.ComponentModel.DataAnnotations;

namespace KundenKartei.Domain;

public class ProductSize
{
    [Key]
    [MaxLength(50)]
    public string ProductSizeId { get; set; } = Guid.NewGuid().ToString();
    
    [MaxLength(100)]
    public string? Name { get; set; }
    
    
    public string ProductId { get; set; }
    public Product Product { get; set; }
}