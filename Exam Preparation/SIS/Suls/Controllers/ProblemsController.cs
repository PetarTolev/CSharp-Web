namespace Suls.Controllers
{
    using Services.Contracts;
    using SIS.HTTP;
    using SIS.MvcFramework;

    public class ProblemsController : Controller
    {
        private readonly IProblemsService problemService;

        public ProblemsController(IProblemsService problemService)
        {
            this.problemService = problemService;
        }

        public HttpResponse Create()
        {
            if (!this.IsUserLoggedIn())
            {
                return this.Redirect("/Users/Login");
            }

            return this.View();
        }

        [HttpPost]
        public HttpResponse Create(string name, int points)
        {
            if (!this.IsUserLoggedIn())
            {
                return this.Redirect("/Users/Login");
            }

            if (name?.Length < 5 || name?.Length > 20)
            {
                return this.Redirect("/Problems/Create");
            }

            if (points < 50 || points > 300)
            {
                return this.Redirect("Problems/Create");
            }

            this.problemService.CreateProblem(name, points);

            return this.Redirect("/");
        }

        public HttpResponse Details(string id)
        {
            if (!this.IsUserLoggedIn())
            {
                return this.Redirect("/Users/Login");
            }

            var viewModel = this.problemService.GetProblemViewModel(id);
            
            return this.View(viewModel);
        }
    }
}
