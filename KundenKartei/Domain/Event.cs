using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace KundenKartei.Domain;

public class Event
{
        [Key]
        [MaxLength(100)]
        public string EventId { get; set; } = Guid.NewGuid().ToString();

        [MaxLength(100)]
        public string? Name { get; set; }

        public User? Organizer { get; set; }

        [MaxLength(100)]
        public string? OrganizerId { get; set; }
        
        public Address? Address { get; set; }

        public DateTime StartTime { get; set; }

        public DateTime EndTime { get; set; }

        [MaxLength(1000)]
        public string? Subject { get; set; }

        public decimal BasePrice { get; set; }
        
        public List<EventParticipant> Participants { get; set; } = [];
}