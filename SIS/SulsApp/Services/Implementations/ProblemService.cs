namespace SulsApp.Services.Implementations
{
    using SulsApp.Models;
    using SulsApp.ViewModels.Problems;
    using SulsApp.ViewModels.Submissions;
    using System.Collections.Generic;
    using System.Linq;

    public class ProblemsService : IProblemsService
    {
        private readonly ApplicationDbContext db;

        public ProblemsService(ApplicationDbContext db)
        {
            this.db = db;
        }

        public void CreateProblem(string name, int points)
        {
            var problem = new Problem
            {
                Name = name,
                Points = points,
            };
            this.db.Problems.Add(problem);
            this.db.SaveChanges();
        }

        public ICollection<ProblemViewModel> GetAllProblems()
        {
            return this.db.Problems.Select(x => new ProblemViewModel
            {
                Count = x.Submissions.Count,
                Id = x.Id,
                Name = x.Name
            }).ToList();
        }

        public ProblemViewModel GetProblemById(string id)
        {
            return this.db.Problems.Where(x => x.Id == id).Select(x => new ProblemViewModel
            {
                Id = x.Id,
                Count = x.Submissions.Count,
                Name = x.Name,
                MaxPoints = x.Points,
                Submissions = x.Submissions.Select(y => new SubmissionProblemDetailsViewModel
                {
                    AchievedResult = y.AchievedResult,
                    CreatedOn = y.CreatedOn,
                    Id = y.Id,
                    Username = y.User.Username
                }).ToList()
            }).FirstOrDefault();
        }
    }
}
