namespace SulsApp.ViewModels.Problems
{
    using SulsApp.ViewModels.Submissions;
    using System.Collections.Generic;

    public class ProblemDetailsViewModel
    {
        public ProblemViewModel Problem { get; set; }

        public ICollection<SubmissionProblemDetailsViewModel> Submissions { get; set; }
    }
}
