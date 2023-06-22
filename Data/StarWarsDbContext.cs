using Microsoft.EntityFrameworkCore;
using StarWarsTestApp.Data.Entities;

namespace StarWarsTestApp.Data
{
    public class StarWarsDbContext : DbContext
    {
        public StarWarsDbContext(DbContextOptions<StarWarsDbContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<Character> Characters { get; set; }

        public DbSet<Film> Films { get; set; }

        public DbSet<CharacterFilms> CharactersFilms { get; set; }

    }
}
