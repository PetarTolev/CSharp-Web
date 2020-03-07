using System.Linq;
using LearnLanguageSystem.Data;
using LearnLanguageSystem.Services.Mapping;
using LearnLanguageSystem.Web.ViewModels.Contests;
using Microsoft.AspNetCore.Identity.UI.V3.Pages.Internal.Account.Manage;

namespace LearnLanguageSystem.Web.Controllers
{
    using Microsoft.AspNetCore.Mvc;

    public class ContestsController : Controller
    {
        private readonly ApplicationDbContext db;

        public ContestsController(ApplicationDbContext db)
        {
            this.db = db;
        }

        public IActionResult Index()
        {
            //var contest = this.db.Contests.To<ContestViewModel>().First();

            return this.View();
        }
    }
}
