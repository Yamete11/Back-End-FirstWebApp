namespace WebApplication13.Entities
{
    public class ActorMovie
    {
        public int IdActorMovie { get; set; }
        public int IdMovie { get; set; }
        public int IdActor { get; set; }
        public string CharacterName { get; set; }

        public virtual Movie IdMovieNavigation { get; set; }
        public virtual Actor IdActorNavigation { get; set; }
    }
}
