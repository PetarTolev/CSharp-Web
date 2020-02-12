using Microsoft.CodeAnalysis.Operations;

namespace Suls.Controllers
{
    using Services.Contracts;
    using SIS.HTTP;
    using SIS.MvcFramework;

    public class SubmissionsController : Controller
    {
        private readonly ISubmissionsService submissionService;

        public SubmissionsController(ISubmissionsService submissionService)
        {
            this.submissionService = submissionService;
        }

        public HttpResponse Create(string id)
        {
            if (!this.IsUserLoggedIn())
            {
                return this.Redirect("/Users/Login");
            }

            var model = this.submissionService.GetProblem(id);

            if (model == null)
            {
                return this.Error("Problem not found!");
            }

            return this.View(model);
        }

        [HttpPost]
        public HttpResponse Create(string problemId, string code)
        {
            if (!this.IsUserLoggedIn())
            {
                return this.Redirect("/Users/Login");
            }

            if (code == null || code.Length < 30)
            {
                return this.Error("Please provide code with at least 30 characters.");
            }

            this.submissionService.CreateSubmission(this.User, problemId, code);

            return this.Redirect("/");
        }

        public HttpResponse Delete(string id)
        {
            if (!this.IsUserLoggedIn())
            {
                return this.Redirect("/Users/Login");
            }

            this.submissionService.DeleteSubmission(id);

            return this.Redirect("/");
        }
    }
}
