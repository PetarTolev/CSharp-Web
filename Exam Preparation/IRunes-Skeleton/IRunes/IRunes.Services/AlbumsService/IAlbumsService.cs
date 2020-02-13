namespace IRunes.Services.AlbumsService
{
    using Models;
    using System;
    using System.Collections.Generic;

    public interface IAlbumsService
    {
        IEnumerable<T> GetAllAlbums<T>(Func<Album, T> selectFunc);

        bool IsNameUsed(string name);

        void CreateAlbum(string name, string cover);

        Album GetAlbumDetails(string id);

        //T GetAlbumDetails<T>(string id, Func<Album, T> selectFunc);

        IEnumerable<Track> GetTracks(string id);
    }
}