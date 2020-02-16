namespace SharedTrip.ViewModels.Trips
{
    using System.Collections.Generic;

    public class AllTripsViewModel
    {
        public IEnumerable<TripsDetailsViewModel> Trips { get; set; }
    }
}
