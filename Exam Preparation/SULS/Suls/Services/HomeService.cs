namespace Suls.Services
{
    using Contracts;
    using Data;
    using ViewModels.Home;
    using System.Linq;

    public class HomeService : IHomeService
    {
        private readonly SULSContext dbContext;

        public HomeService(SULSContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public LoggedInViewModel GetLoggedInModel()
        {
            var problems = this.dbContext.Problems
                .Select(p => new IndexProblemViewModel
                {
                    Id = p.Id,
                    Name = p.Name,
                    Count = p.Submissions.Count,
                })
                .ToList();

            var loggedInViewModel = new LoggedInViewModel
            {
                Problems = problems,
            };

            return loggedInViewModel;
        }
    }
}