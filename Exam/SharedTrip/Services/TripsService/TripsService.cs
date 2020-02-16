using System;
using System.Collections.Generic;
using System.Linq;
using SharedTrip.InputModels.Trips;
using SharedTrip.Models;
using SharedTrip.ViewModels.Trips;

namespace SharedTrip.Services.TripsService
{
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
                        DepartureTime = t.DepartureTime.ToString(), //todo: add format
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
                DepartureTime = DateTime.Parse(input.DepartureTime), //todo: not sure for datetime format
                StartPoint = input.StartPoint,
                EndPoint = input.EndPoint,
                ImagePath = input.ImagePath,
                Seats = input.Seats,
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
