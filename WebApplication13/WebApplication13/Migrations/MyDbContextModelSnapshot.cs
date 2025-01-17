﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WebApplication13.Context;

namespace WebApplication13.Migrations
{
    [DbContext(typeof(MyDbContext))]
    partial class MyDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.17")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("WebApplication13.Entities.Actor", b =>
                {
                    b.Property<int>("IdActor")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Nickname")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Surname")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("IdActor")
                        .HasName("Actor_pk");

                    b.ToTable("Actors");
                });

            modelBuilder.Entity("WebApplication13.Entities.ActorMovie", b =>
                {
                    b.Property<int>("IdActorMovie")
                        .HasColumnType("int");

                    b.Property<string>("CharacterName")
                        .HasMaxLength(70)
                        .HasColumnType("nvarchar(70)");

                    b.Property<int>("IdActor")
                        .HasColumnType("int");

                    b.Property<int>("IdMovie")
                        .HasColumnType("int");

                    b.HasKey("IdActorMovie")
                        .HasName("ActorMovie_pk");

                    b.HasIndex("IdActor");

                    b.HasIndex("IdMovie");

                    b.ToTable("ActorMovies");
                });

            modelBuilder.Entity("WebApplication13.Entities.Movie", b =>
                {
                    b.Property<int>("IdMovie")
                        .HasColumnType("int");

                    b.Property<string>("Genre")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("Grade")
                        .HasMaxLength(50)
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("IdMovie")
                        .HasName("Movie_pk");

                    b.ToTable("Movies");
                });

            modelBuilder.Entity("WebApplication13.Entities.ActorMovie", b =>
                {
                    b.HasOne("WebApplication13.Entities.Actor", "IdActorNavigation")
                        .WithMany("ActorMovies")
                        .HasForeignKey("IdActor")
                        .HasConstraintName("ActorMovieIdActor")
                        .IsRequired();

                    b.HasOne("WebApplication13.Entities.Movie", "IdMovieNavigation")
                        .WithMany("ActorMovies")
                        .HasForeignKey("IdMovie")
                        .HasConstraintName("ActorMovieIdMovie")
                        .IsRequired();

                    b.Navigation("IdActorNavigation");

                    b.Navigation("IdMovieNavigation");
                });

            modelBuilder.Entity("WebApplication13.Entities.Actor", b =>
                {
                    b.Navigation("ActorMovies");
                });

            modelBuilder.Entity("WebApplication13.Entities.Movie", b =>
                {
                    b.Navigation("ActorMovies");
                });
#pragma warning restore 612, 618
        }
    }
}
