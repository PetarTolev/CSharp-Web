namespace Andreys.App.Controllers
{
    using Andreys.Services.Home;
    using SIS.HTTP;
    using SIS.MvcFramework;
    using System.Linq;
    using ViewModels.Home;

    public class HomeController : Controller
    {
        private readonly IHomeService homeService;

        public HomeController(IHomeService homeService)
        {
            this.homeService = homeService;
        }

        [HttpGet("/")]
        public HttpResponse Index()
        {
            if (this.IsUserLoggedIn())
            {
                return this.Home();
            }

            return this.View();
        }

        public HttpResponse Home()
        {
            if (!this.IsUserLoggedIn())
            {
                return this.Redirect("/");
            }

            var products = this.homeService.GetAllProducts().Select(p =>
                new ProductHomeViewModel
                {
                    Id = p.Id,
                    Name = p.Name,
                    ImageUrl = p.ImageUrl,
                    Price = p.Price,
                });

            var model = new LoggedInHomeViewModel
            {
                Products = products,
            };

            return this.View(model);
        }
    }
}
