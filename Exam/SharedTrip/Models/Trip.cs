namespace SharedTrip.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Trip
    {
        [Key]
        public string Id { get; set; }

        [Required]
        public string StartPoint { get; set; }
        
        [Required]
        public string EndPoint { get; set; }
        
        [Required]
        public DateTime DepartureTime { get; set; }
        
        [Required]
        public int Seats { get; set; }
        
        [Required]
        public string Description { get; set; }

        public string ImagePath { get; set; }

        public virtual ICollection<UserTrip> UserTrips { get; set; }
    }
}
