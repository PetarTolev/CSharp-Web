namespace SharedTrip.Models
{
    using System.ComponentModel.DataAnnotations;

    public class UserTrip
    {
        [Required]
        public string TripId { get; set; }
        public virtual Trip Trip { get; set; }

        [Required]
        public string UserId { get; set; }
        public virtual User User { get; set; }
    }
}
