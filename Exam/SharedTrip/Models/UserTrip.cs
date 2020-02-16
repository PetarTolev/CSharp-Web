namespace SharedTrip.Models
{
    using System.ComponentModel.DataAnnotations;

    public class UserTrip
    {
        [Required]
        public int TripId { get; set; }
        public virtual Trip Trip { get; set; }

        [Required]
        public int UserId { get; set; }
        public virtual User User { get; set; }
    }
}
