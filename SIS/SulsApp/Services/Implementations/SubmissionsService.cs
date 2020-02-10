namespace SulsApp.Services.Implementations
{
    using SulsApp.Models;
    using System;
    using System.Linq;

    public class SubmissionsService : ISubmissionsService
    {
        private readonly ApplicationDbContext db;

        public SubmissionsService(ApplicationDbContext db)
        {
            this.db = db;
        }

        public void Create(string code, string problemId, string userId)
        {
            var rnd = new Random();
            var problem = this.db.Problems.FirstOrDefault(x => x.Id == problemId);

            var achievedResult = rnd.Next(0, problem.Points);
            var createdOn = DateTime.UtcNow;
            var currentUser = this.db.Users.FirstOrDefault(x => x.Id == userId);

            var submission = new Submission()
            {
                AchievedResult = achievedResult,
                Code = code,
                User = currentUser,
                UserId = currentUser.Id,
                CreatedOn = createdOn,
                Problem = problem
            };

            this.db.Submissions.Add(submission);
            this.db.SaveChanges();
        }

        public void Delete(string id)
        {
            var entity = this.db.Submissions.FirstOrDefault(x => x.Id == id);
            this.db.Submissions.Remove(entity);
            this.db.SaveChanges();
        }
    }
}
