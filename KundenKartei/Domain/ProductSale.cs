using System;
using System.ComponentModel.DataAnnotations;

namespace KundenKartei.Domain;

public class ProductSale
{
    [Key]
    [MaxLength(100)]
    public string SaleId { get; set; } = Guid.NewGuid().ToString();

    public User? Seller { get; set; }

    [MaxLength(100)]
    public string SellerId { get; set; }
    
    public Customer? Customer { get; set; }

    [MaxLength(100)]
    public string? CustomerId { get; set; }
    
    public Product? Product { get; set; }

    [MaxLength(100)]
    public string? ProductId { get; set; }

    public ProductColor? Color { get; set; }

    public ProductSize? Size { get; set; }
    
    public int Quantity { get; set; }

    public decimal UnitPrice { get; set; }
    
    public decimal Price { get; set; }

    public DateTime BillReceivedOn { get; set; }

    public DateTime BillPayedOn { get; set; }

    public PaymentMethod PaymentMethod { get; set; }
    
}