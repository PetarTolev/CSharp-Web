using IRunes.App.ViewModels.Home;
using IRunes.Services.HomeService;

namespace IRunes.App.Controllers
{
    using SIS.HTTP;
    using SIS.MvcFramework;

    public class HomeController : Controller
    {
        private readonly IHomeService homeService;

        public HomeController(IHomeService homeService)
        {
            this.homeService = homeService;
        }

        [HttpGet("/")]
        public HttpResponse Home()
        {
            if (this.IsUserLoggedIn())
            {
                var username = this.homeService.GetUserName(this.User);

                var model = new LoggedInHomeViewModel
                {
                    Username = username,
                };

                return this.View(model);
            }

            return this.Index();
        }

        public HttpResponse Index()
        {
            return this.View();
        }
    }
}
