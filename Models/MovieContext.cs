using Microsoft.EntityFrameworkCore;

namespace MovieApp.Models
{
    public class MovieContext : DbContext
    {
        //DbSet<Movie> Movies is a property that represent the collection of all Movie Object
        public DbSet<Movie> Movies { get; set; } = null!;
        public DbSet<Genre> Genres { get; set; } = null!;

        public MovieContext(DbContextOptions<MovieContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Genre>().HasData(
                new Genre() { GenreId = "A", Name = "Action"},
                new Genre() { GenreId = "C", Name = "Comedy" },
                new Genre() { GenreId = "D", Name = "Drama" },
                new Genre() { GenreId = "H", Name = "Horror" },
                new Genre() { GenreId = "M", Name = "Musical" },
                new Genre() { GenreId = "R", Name = "RomCom" },
                new Genre() { GenreId = "S", Name = "SciFi" }
                );
            modelBuilder.Entity<Movie>().HasData(
                new Movie() { MovieId = 1, Name = "lewe", Year = 2006, Rating = 5, GenreId = "C" },
                new Movie() { MovieId = 2, Name = "Nnim", Year = 1995, Rating = 5,GenreId = "D"},
                new Movie() { MovieId = 3, Name = "Money Hiest", Year = 2012, Rating = 4, GenreId = "A" }
                );
        }
    }
}
