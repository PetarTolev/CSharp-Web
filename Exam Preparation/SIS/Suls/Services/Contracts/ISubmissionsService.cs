namespace Suls.Services.Contracts
{
    using ViewModels.Submissions;

    public interface ISubmissionsService
    {
        SubmissionsCreateViewModel GetProblem(string id);

        void CreateSubmission(string userId, string problemId, string code);

        void DeleteSubmission(string submissionId);
    }
}