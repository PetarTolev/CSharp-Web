namespace SharedTrip.Controllers
{
    using InputModels.Trips;
    using Services.TripsService;
    using SIS.HTTP;
    using SIS.MvcFramework;
    using ViewModels.Trips;

    public class TripsController : Controller
    {
        private readonly ITripsService tripsService;

        public TripsController(ITripsService tripsService)
        {
            this.tripsService = tripsService;
        }

        public HttpResponse All()
        {
            if (!this.IsUserLoggedIn())
            {
                return this.Redirect("/Users/Login");
            }

            var trips = this.tripsService.GetAllTrips();

            var model = new AllTripsViewModel
            {
                Trips = trips,
            };

            return this.View(model);
        }

        public HttpResponse Details(string tripId)
        {
            if (!this.IsUserLoggedIn())
            {
                return this.Redirect("/Users/Login");
            }

            var trip = this.tripsService.GetTrip(tripId);

            var model = new FullTripDetailsViewModel()
            {
                Id = trip.Id,
                StartPoint = trip.StartPoint,
                EndPoint = trip.EndPoint,
                DepartureTime = trip.DepartureTime.ToString(),
                Seats = trip.Seats,
                ImagePath = trip.ImagePath,
                Description = trip.Description,
            };

            return this.View(model);
        }

        public HttpResponse Add()
        {
            if (!this.IsUserLoggedIn())
            {
                return this.Redirect("/Users/Login");
            }

            return this.View();
        }

        [HttpPost]
        public HttpResponse Add(TripAddInputModel input)
        {
            if (!this.IsUserLoggedIn())
            {
                return this.Redirect("/Users/Login");
            }

            if ( input.Seats == "" || input.DepartureTime == "" || input.Description == "" ||
                 input.EndPoint == "" || input.StartPoint == "" ||
                int.Parse(input.Seats) < 2 || int.Parse(input.Seats) > 6 ||
                input.Description.Length < 0 || input.Description.Length > 60)
            {
                return this.Redirect("Add");
            }

            this.tripsService.AddTrip(input);

            return this.Redirect("All");
        }

        public HttpResponse AddUserToTrip(string tripId)
        {
            if (!IsUserLoggedIn())
            {
                return this.Redirect("/Users/Login");
            }

            if (this.tripsService.IsUserJoinedThisTrip(this.User, tripId))
            {
                return this.Details(tripId);
            }

            this.tripsService.JoinUserToTrip(this.User, tripId);

            return this.Redirect("All");
        }
    }
}
