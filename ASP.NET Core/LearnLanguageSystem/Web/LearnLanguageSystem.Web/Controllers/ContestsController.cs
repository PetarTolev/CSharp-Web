namespace LearnLanguageSystem.Web.Controllers
{
    using Microsoft.AspNetCore.Mvc;

    public class ContestsController : Controller
    {
        public IActionResult Index()
        {
            return this.View();
        }
    }
}
