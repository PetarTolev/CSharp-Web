namespace Andreys.App.Controllers
{
    using SIS.HTTP;
    using SIS.MvcFramework;

    public class HomeController : Controller
    {
        public HomeController()
        {
            
        }

        [HttpGet("/")]
        public HttpResponse Index()
        { 
            return this.View();
        }

        public HttpResponse Home()
        {
            if (!this.IsUserLoggedIn())
            {
                return this.Redirect("/");
            }

            return this.View();
        }
    }
}
