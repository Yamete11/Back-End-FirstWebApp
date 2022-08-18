using System.Collections.Generic;

namespace WebApplication13.Entities
{
    public class Actor
    {
        public Actor()
        {
            ActorMovies = new HashSet<ActorMovie>();
        }

        public int IdActor { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Nickname { get; set; }

        public virtual ICollection<ActorMovie> ActorMovies { get; set; }
    }
}
