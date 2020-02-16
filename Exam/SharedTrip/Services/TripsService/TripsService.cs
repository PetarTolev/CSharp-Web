namespace SharedTrip.Services.TripsService
{
    using Data;
    using InputModels.Trips;
    using Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using ViewModels.Trips;


    public class TripsService : ITripsService
    {
        private readonly ApplicationDbContext db;

        public TripsService(ApplicationDbContext db)
        {
            this.db = db;
        }

        public IEnumerable<TripsDetailsViewModel> GetAllTrips()
        {
            //todo: refactor

            return this.db.Trips.Select(t =>
                    new TripsDetailsViewModel
                    {
                        Id = t.Id,
                        DepartureTime = t.DepartureTime.ToString("dd/MM/yyyy HH:mm"),
                        EndPoint = t.EndPoint,
                        StartPoint = t.StartPoint,
                        Seats = t.Seats,
                    })
                .ToList();
        }

        public void AddTrip(TripAddInputModel input)
        {
            var trip = new Trip
            {
                DepartureTime = DateTime.Parse(input.DepartureTime),
                StartPoint = input.StartPoint,
                EndPoint = input.EndPoint,
                ImagePath = input.ImagePath,
                Seats = int.Parse(input.Seats),
                Description = input.Description,
            };

            this.db.Trips.Add(trip);
            db.SaveChanges();
        }

        public Trip GetTrip(string id)
        {
            return this.db.Trips.FirstOrDefault(t => t.Id == id);
        }

        public void JoinUserToTrip(string userId, string tripId)
        {
            var userTrip = new UserTrip
            {
                TripId = tripId,
                UserId = userId
            };

            this.db.UserTrips.Add(userTrip);
            this.db.SaveChanges();
        }

        public bool IsUserJoinedThisTrip(string user, string tripId)
        {
            return this.db.UserTrips.Any(ut => ut.UserId == user && ut.TripId == tripId);
        }
    }
}
