using Microsoft.EntityFrameworkCore;
using System.Reflection;
using WebApplication13.Entities;
using WebApplication13.Entities.Configuration;

namespace WebApplication13.Context
{
    public class MyDbContext : DbContext
    {
        public virtual DbSet<Movie> Movies { get; set; }
        public virtual DbSet<Actor> Actors { get; set; }
        public virtual DbSet<ActorMovie> ActorMovies { get; set; }


        public MyDbContext()
        {

        }

        public MyDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(
                typeof(MovieEConfiguration).GetTypeInfo().Assembly);


        }


    }
}
