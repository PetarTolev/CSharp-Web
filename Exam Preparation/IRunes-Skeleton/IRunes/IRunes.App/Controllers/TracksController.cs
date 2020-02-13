namespace IRunes.App.Controllers
{
    using Services.TracksService;
    using SIS.HTTP;
    using SIS.MvcFramework;
    using ViewModels.Tracks;

    public class TracksController : Controller
    {
        private readonly ITracksService tracksService;

        public TracksController(ITracksService tracksService)
        {
            this.tracksService = tracksService;
        }

        public HttpResponse Create(string albumId)
        {
            if (!this.IsUserLoggedIn())
            {
                return this.Redirect("/Users/Login");
            }

            var model = new CreateViewModel
            {
                AlbumId = albumId,
            };

            return this.View(model);
        }

        [HttpPost]
        public HttpResponse Create(string albumId, string name, string link, string price)
        {
            if (!this.IsUserLoggedIn())
            {
                return this.Redirect("/Users/Login");
            }

            if (name.Length <= 4 || name.Length >= 20)
            {
                return this.Create(albumId); //todo: error message
            }

            this.tracksService.CreateTrack(albumId, name, link, price);

            return this.Redirect("/Albums/Details?id=" + albumId);
        }

        public HttpResponse Details(string albumId)
        {
            if (!this.IsUserLoggedIn())
            {
                return this.Redirect("/Users/Login");
            }

            var track =this.tracksService.GetTrackDetails(albumId);

            if (track == null)
            {
                return this.Redirect("/"); //todo: error with message "track doesn't exist!"
            }

            var model = new TrackDetailsViewModel
            {
                Name = track.Name,
                AlbumId = track.AlbumId,
                IFrameSource = track.Link,
                Price = track.Price
            };

            return this.View(model);
        }
    }
}
