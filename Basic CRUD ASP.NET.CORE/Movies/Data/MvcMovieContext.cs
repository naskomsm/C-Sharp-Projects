namespace MvcMovie.Data
{
    using Microsoft.EntityFrameworkCore;
    using MvcMovie.Models;

    public class MvcMovieContext : DbContext
    {
        public MvcMovieContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Movie> Movies { get; set; }
    }
}
