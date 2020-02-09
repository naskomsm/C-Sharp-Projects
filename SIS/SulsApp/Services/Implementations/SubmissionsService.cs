namespace SulsApp.Services.Implementations
{
    using SulsApp.Models;
    using System;

    public class SubmissionsService : ISubmissionsService
    {
        private readonly ApplicationDbContext db;

        public SubmissionsService(ApplicationDbContext db)
        {
            this.db = db;
        }

        public void Create(string text)
        {
            var rnd = new Random();

            // TODO

            var submission = new Submission()
            {
                
            };
        }
    }
}
