using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace WebApplication13.Entities.Configuration
{
    public class MovieEConfiguration : IEntityTypeConfiguration<Movie>
    {
        public void Configure(EntityTypeBuilder<Movie> builder)
        {
            builder.HasKey(x => x.IdMovie).HasName("Movie_pk");
            builder.Property(x => x.IdMovie).ValueGeneratedNever();

            builder.Property(x => x.Title).HasMaxLength(50);
            builder.Property(x => x.Genre).HasMaxLength(50);
            builder.Property(x => x.Grade).HasMaxLength(50);

            builder.ToTable("Movies");
        }
    }
}
