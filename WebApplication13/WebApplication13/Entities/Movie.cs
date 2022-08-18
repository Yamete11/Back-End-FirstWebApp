using System.Collections.Generic;

namespace WebApplication13.Entities
{
    public class Movie
    {
        public Movie()
        {
            ActorMovies = new HashSet<ActorMovie>();
        }
        public int IdMovie { get; set; }
        public string Title { get; set; }
        public string Genre { get; set; }
        public int Grade { get; set; }

        public virtual ICollection<ActorMovie> ActorMovies { get; set; }
    }
}
