namespace SulsApp.ViewModels.Home
{
    using SulsApp.ViewModels.Problems;
    using System.Collections.Generic;

    public class IndexLoggedInViewModel
    {
        public ICollection<ProblemViewModel> Problems { get; set; }
    }
}
