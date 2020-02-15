namespace IRunes.Services.AlbumsService
{
    using Data;
    using Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class AlbumsService : IAlbumsService
    {
        private readonly RunesDbContext db;

        public AlbumsService(RunesDbContext db)
        {
            this.db = db;
        }

        public IEnumerable<T> GetAllAlbums<T>(Func<Album, T> selectFunc)
        {
            return this.db.Albums.Select(selectFunc);
        }

        public bool IsNameUsed(string name)
        {
            return this.db.Albums.Any(a => a.Name == name);
        }

        public void CreateAlbum(string name, string cover)
        {
            var album = new Album
            {
                Name = name,
                Cover = cover,
            };

            this.db.Albums.Add(album);
            this.db.SaveChanges();
        }

        public Album GetAlbumDetails(string id)
        {
           return this.db.Albums
                .FirstOrDefault(a => a.Id == id);
        }

        public IEnumerable<Track> GetTracks(string id)
        {
            return this.db.Tracks.Where(t => t.AlbumId == id);
        }
    }
}
