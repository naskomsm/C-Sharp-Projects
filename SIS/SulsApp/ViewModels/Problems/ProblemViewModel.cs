﻿namespace SulsApp.ViewModels.Problems
{
    using SulsApp.ViewModels.Submissions;
    using System.Collections.Generic;

    public class ProblemViewModel
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public int Count { get; set; }

        public int MaxPoints { get; set; }

        public ICollection<SubmissionProblemDetailsViewModel> Submissions { get; set; }
    }
}
