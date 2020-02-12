namespace Suls.App.Controllers
{
    using Services.Contracts;
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
        public HttpResponse Index()
        {
            if (this.IsUserLoggedIn())
            {
                var viewModel = this.homeService.GetLoggedInModel();

                return this.View(viewModel, "IndexLoggedIn");
            }

            return this.View();
        }

        public HttpResponse IndexLoggedIn()
        {
            return this.Index();
        }
    }
}