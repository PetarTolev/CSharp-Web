namespace Suls.App
{
    using Data;
    using Microsoft.EntityFrameworkCore;
    using Services;
    using Services.Contracts;
    using SIS.HTTP;
    using SIS.MvcFramework;
    using System.Collections.Generic;

    public class StartUp : IMvcApplication
    {
        public void ConfigureServices(IServiceCollection serviceCollection)
        {
            serviceCollection.Add<IUsersService, UsersService>();
            serviceCollection.Add<IProblemsService, ProblemsService>();
            serviceCollection.Add<IHomeService, HomeService>();
            serviceCollection.Add<ISubmissionsService, SubmissionsService>();
        }

        public void Configure(IList<Route> routeTable)
        {
            var db = new SULSContext();
            db.Database.Migrate();
        }
    }
}