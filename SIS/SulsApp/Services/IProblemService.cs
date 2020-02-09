namespace SulsApp.Services
{
    using SulsApp.ViewModels.Problems;
    using System.Collections.Generic;

    public interface IProblemsService
    {
        void CreateProblem(string name, int points);

        ICollection<ProblemViewModel> GetAllProblems();

        ProblemViewModel GetProblemById(string id);
    }
}
