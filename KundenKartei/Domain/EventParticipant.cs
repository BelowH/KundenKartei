using System;
using System.ComponentModel.DataAnnotations;

namespace KundenKartei.Domain;

public class EventParticipant
{
    [Key]
    [MaxLength(100)]
    public string EventParticipantId { get; set; } = Guid.NewGuid().ToString();
    
    public Event? Event { get; set; }
    
    [MaxLength(100)]
    public string? EventId { get; set; }
    
    
    public Customer? Customer { get; set; }

    [MaxLength(100)]
    public string? CustomerId { get; set; }

    public bool HasAttended { get; set; }

    public decimal Price { get; set; }

    public DateTime BillReceivedOn { get; set; }

    public DateTime BillPayedOn { get; set; }

    public PaymentMethod Method { get; set; }
    
}