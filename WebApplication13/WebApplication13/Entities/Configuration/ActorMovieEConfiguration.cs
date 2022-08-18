using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace WebApplication13.Entities.Configuration
{
    public class ActorMovieEConfiguration : IEntityTypeConfiguration<ActorMovie>
    {
        public void Configure(EntityTypeBuilder<ActorMovie> builder)
        {
            builder.HasKey(t => t.IdActorMovie).HasName("ActorMovie_pk");
            builder.Property(t => t.IdActorMovie).ValueGeneratedNever();

            builder.Property(t => t.CharacterName).HasMaxLength(70);

            builder.HasOne(t => t.IdActorNavigation)
                .WithMany(t => t.ActorMovies)
                .HasForeignKey(t => t.IdActor)
                .HasConstraintName("ActorMovieIdActor")
                .OnDelete(DeleteBehavior.ClientSetNull);

            builder.HasOne(t => t.IdMovieNavigation)
                .WithMany(t => t.ActorMovies)
                .HasForeignKey(t => t.IdMovie)
                .HasConstraintName("ActorMovieIdMovie")
                .OnDelete(DeleteBehavior.ClientSetNull);


            builder.ToTable("ActorMovies");
        }
    }
}
