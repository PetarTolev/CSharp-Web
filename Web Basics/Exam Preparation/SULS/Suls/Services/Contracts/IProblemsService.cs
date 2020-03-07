namespace Suls.Services.Contracts
{
    using ViewModels.Problems;

    public interface IProblemsService
    {
        void CreateProblem(string name, int point);

        ProblemViewModel GetProblemViewModel(string problemId);
    }
}