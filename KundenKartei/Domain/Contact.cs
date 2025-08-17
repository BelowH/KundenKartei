using System;
using System.ComponentModel.DataAnnotations;

namespace KundenKartei.Domain;

public class Contact
{
    [Key]
    public string ContactId { get; set; } = Guid.NewGuid().ToString();

    public string Phone { get; set; }

    public string Mobile { get; set; }

    public string Email { get; set; }

    public string AccountNumber { get; set; }

}