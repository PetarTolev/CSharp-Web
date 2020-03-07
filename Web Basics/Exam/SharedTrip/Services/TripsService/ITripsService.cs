namespace SharedTrip.Services.TripsService
{
    using InputModels.Trips;
    using Models;
    using System.Collections.Generic;
    using ViewModels.Trips;

    public interface ITripsService
    {
        IEnumerable<TripsDetailsViewModel> GetAllTrips();

        void AddTrip(TripAddInputModel input);

        Trip GetTrip(string id);

        void JoinUserToTrip(string userId, string tripId);

        bool IsUserJoinedThisTrip(string user, string tripId);
    }
}