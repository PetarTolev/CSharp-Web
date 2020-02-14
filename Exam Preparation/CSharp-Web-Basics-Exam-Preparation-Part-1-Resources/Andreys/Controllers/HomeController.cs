namespace Andreys.App.Controllers
{
    using SIS.HTTP;
    using SIS.MvcFramework;

    public class HomeController : Controller
    {
        public HomeController()
        {
            
        }

        public HttpResponse Index()
        { 
            return this.View();
        }
    }
}
