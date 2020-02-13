namespace IRunes.App.Controllers
{
    using Services.AlbumsService;
    using SIS.HTTP;
    using SIS.MvcFramework;
    using System.Linq;
    using ViewModels.Albums;

    public class AlbumsController : Controller
    {
        private readonly IAlbumsService albumsService;

        public AlbumsController(IAlbumsService albumsService)
        {
            this.albumsService = albumsService;
        }

        public HttpResponse All()
        {
            if (!this.IsUserLoggedIn())
            {
                return this.Redirect("/Users/Login");
            }

            var model = new AllAlbumsViewModel
            {
                Albums = this.albumsService.GetAllAlbums(a => new AlbumNameViewModel
                {
                    Id = a.Id,
                    Name = a.Name
                }),
            };

            return this.View(model);
        } 
        
        public HttpResponse Create()
        {
            if (!this.IsUserLoggedIn())
            {
                return this.Redirect("/Users/Login");
            }

            return this.View();
        }

        [HttpPost]
        public HttpResponse Create(string name, string cover)
        {
            if (this.albumsService.IsNameUsed(name))
            {
                return this.Create();
            }

            if (name.Length < 4 || name.Length > 20)
            {
                return this.Create();
            }

            this.albumsService.CreateAlbum(name, cover);

            return this.All();
        }

        public HttpResponse Details(string id)
        {
            if (!this.IsUserLoggedIn())
            {
                return this.Redirect("/Users/Login");
            }

            var album = this.albumsService.GetAlbumDetails(id);
            var tracks = this.albumsService.GetTracks(id);

            if (album == null)
            {
                return this.Redirect("/"); //todo: redirect to error page
            }

            var model = new AlbumDetailsViewModel
            {
                Id = album.Id,
                Name = album.Name,
                Cover = album.Cover,
                Price = album.Price,
                Tracks = tracks.Select(t => new AlbumTracksViewModel
                {
                    Id = t.Id,
                    Name = t.Name,
                }),
            };

            return this.View(model);
        }
    }
}