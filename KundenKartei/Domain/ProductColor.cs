using System;
using System.ComponentModel.DataAnnotations;

namespace KundenKartei.Domain;

public class ProductColor
{
    [Key]
    [MaxLength(50)]
    public string ProductColorId { get; set; } = Guid.NewGuid().ToString();

    [MaxLength(100)]   
    public string? Name { get; set; }

    [MaxLength(7)]
    public string? Hex { get; set; }
    
    public string ProductId { get; set; }
    public Product Product { get; set; }
    
}