using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace WebApplication13.Entities.Configuration
{
    public class ActorEConfiguration : IEntityTypeConfiguration<Actor>
    {
        public void Configure(EntityTypeBuilder<Actor> builder)
        {
            builder.HasKey(x => x.IdActor).HasName("Actor_pk");
            builder.Property(x => x.IdActor).ValueGeneratedNever();

            builder.Property(x => x.Name).HasMaxLength(50);
            builder.Property(x => x.Surname).HasMaxLength(50);
            builder.Property(x => x.Nickname).HasMaxLength(50);

            builder.ToTable("Actors");
        }
    }
}
