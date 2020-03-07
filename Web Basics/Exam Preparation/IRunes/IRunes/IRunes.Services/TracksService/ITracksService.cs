namespace IRunes.Services.TracksService
{
    using Models;

    public interface ITracksService
    {
        void CreateTrack(string albumId, string name, string link, string price);

        Track GetTrackDetails(string albumId);
    }
}