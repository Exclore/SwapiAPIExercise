using Microsoft.EntityFrameworkCore;
using StarWarsAPIExercise.Models;

namespace StarWarsAPIExercise.DataAccess
{
    public class StarshipContext : DbContext
    {

        public StarshipContext(DbContextOptions<StarshipContext> options)
            : base(options)
        {

        }

        public DbSet<Starship> Starships { get; set; }
        
    }
}
