namespace Suls.Services
{
    using Contracts;
    using Data;
    using Models;
    using System;
    using System.Linq;
    using ViewModels.Submissions;

    public class SubmissionsService : ISubmissionsService
    {
        private readonly SULSContext dbContext;
        private readonly Random random;

        public SubmissionsService(SULSContext dbContext, Random random)
        {
            this.dbContext = dbContext;
            this.random = random;
        }

        public SubmissionsCreateViewModel GetProblem(string id)
        {
            return this.dbContext.Problems
                .Where(p => p.Id == id)
                .Select(p => new SubmissionsCreateViewModel
                {
                    ProblemId = p.Id,
                    Name = p.Name,
                })
                .FirstOrDefault();
        }

        public void CreateSubmission(string userId, string problemId, string code)
        {
            var problem = this.dbContext.Problems
                .FirstOrDefault(p => p.Id == problemId);

            var submission = new Submission
            {
                CreatedOn = DateTime.UtcNow,
                UserId = userId,
                ProblemId = problemId,
                Code = code,
                AchievedResult = this.random.Next(0, problem.Points + 1),
            };

            this.dbContext.Submissions.Add(submission);
            this.dbContext.SaveChanges();
        }

        public void DeleteSubmission(string submissionId)
        {
            var submission = this.dbContext.Submissions
                .FirstOrDefault(s => s.Id == submissionId);

            this.dbContext.Submissions.Remove(submission);
            this.dbContext.SaveChanges();
        }
    }
}
