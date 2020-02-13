using System.Linq;
using System.Text.RegularExpressions;

namespace IRunes.Services.TracksService
{
    using Data;
    using Models;

    public class TracksService : ITracksService
    {
        private readonly RunesDbContext db;

        public TracksService(RunesDbContext db)
        {
            this.db = db;
        }

        public void CreateTrack(string albumId, string name, string link, string price)
        {
            if (link.Contains("youtube"))
            {
                var regex = new Regex(@"youtu(?:\.be|be\.com)/(?:(.*)v(/|=)|(.*/)?)(?<id>[a-zA-Z0-9-_]+)", RegexOptions.IgnoreCase);
                var videoId = regex.Match(link).Groups["id"];
                 link = $"https://www.youtube.com/embed/{videoId}";
            }

            var track = new Track
            {
                AlbumId = albumId,
                Name = name,
                Link = link,
                Price = decimal.Parse(price),
            };

            this.db.Tracks.Add(track);
            this.db.SaveChanges();
        }

        public Track GetTrackDetails(string albumId)
        {
            return this.db.Tracks.FirstOrDefault(t => t.AlbumId == albumId);
        }
    }
}
