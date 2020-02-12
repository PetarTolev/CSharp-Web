namespace Suls.Services
{
    using Contracts;
    using Data;
    using Models;
    using System.Globalization;
    using System.Linq;
    using ViewModels.Problems;

    public class ProblemsService : IProblemsService
    {
        private readonly SULSContext dbContext;

        public ProblemsService(SULSContext dbContext)
        {
            this.dbContext = dbContext;
        }
        
        public void CreateProblem(string name, int points)
        {
            var problem = new Problem
            {
                Name = name,
                Points = points,
            };

            this.dbContext.Problems.Add(problem);
            this.dbContext.SaveChanges();
        }

        public ProblemViewModel GetProblemViewModel(string problemId)
        {
            var problem = this.dbContext.Problems
                .Where(p => p.Id == problemId)
                .Select(p => new ProblemViewModel
                {
                    Name = p.Name,
                    Problems = p.Submissions
                        .Select(s => new ProblemSubmissionsDetailViewModel
                        {
                            Username = s.User.Username,
                            AchievedResult = s.AchievedResult,
                            MaxPoints = p.Points,
                            CreatedOn = s.CreatedOn.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture),
                            SubmissionId = s.Id
                        })
                        .ToList()
                })
                .FirstOrDefault();

            return problem;
        }
    }
}
