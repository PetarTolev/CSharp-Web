namespace IRunes.App
{
    using Data;
    using Services.AlbumsService;
    using Services.HomeService;
    using Services.TracksService;
    using Services.UsersService;
    using SIS.HTTP;
    using SIS.MvcFramework;
    using System.Collections.Generic;

    public class Startup : IMvcApplication
    {
        public void Configure(IList<Route> serverRoutingTable)
        {
            using (var db = new RunesDbContext())
            {
                db.Database.EnsureCreated();
            }
        }

        public void ConfigureServices(IServiceCollection serviceCollection)
        {
            serviceCollection.Add<IAlbumsService, AlbumsService>();
            serviceCollection.Add<IHomeService, HomeService>();
            serviceCollection.Add<ITracksService, TracksService>();
            serviceCollection.Add<IUsersService, UsersService>();
        }
    }
}
