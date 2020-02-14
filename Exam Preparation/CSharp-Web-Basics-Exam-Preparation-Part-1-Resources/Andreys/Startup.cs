namespace Andreys.App
{
    using Andreys.Services.Home;
    using Andreys.Services.Products;
    using Data;
    using Services.Users;
    using SIS.HTTP;
    using SIS.MvcFramework;
    using System.Collections.Generic;

    public class Startup : IMvcApplication
    {
        public void Configure(IList<Route> serverRoutingTable)
        {
            using (var db = new AndreysDbContext())
            {
                db.Database.EnsureCreated();
            }
        }

        public void ConfigureServices(IServiceCollection serviceCollection)
        {
            serviceCollection.Add<IHomeService, HomeService>();
            serviceCollection.Add<IProductsService, ProductsService>();
            serviceCollection.Add<IUsersService, UsersService>();
        }
    }
}
