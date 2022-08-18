using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using WebApplication13.Context;
using WebApplication13.DTOs;
using WebApplication13.Entities;

namespace WebApplication13.Services
{
    public class MovieService : IMovieService
    {

        readonly MyDbContext _context;

        public MovieService(MyDbContext context)
        {
            _context = context;
        }

        //Add new movie to the database
        public async Task<MethodResultDTO> AddMovie(MovieDTO movieDTO)
        {
            IDbContextTransaction transaction = await _context.Database.BeginTransactionAsync();

            Movie movie = _context.Movies.SingleOrDefault(x => x.Title.Trim().ToLower() == movieDTO.Title.Trim().ToLower());

            if (movie != null)
            {
                transaction.Rollback();

                return new MethodResultDTO
                {
                    HttpStatusCode = HttpStatusCode.NotFound,
                    Message = "Movie already exists"
                };
            }


            await AddMovieAsync(movieDTO);

            await _context.SaveChangesAsync();

            await transaction.CommitAsync();

            return new MethodResultDTO
            {
                HttpStatusCode = HttpStatusCode.OK,
                Message = "Added"
            };

        }

        public async Task<Movie> AddMovieAsync(MovieDTO movieDTO)
        {
            int newId = !await _context.Movies.AnyAsync() ? 1 : await _context.Movies.MaxAsync(x => x.IdMovie) + 1;

            Movie movie = new Movie
            {
                IdMovie = newId,
                Title = movieDTO.Title,
                Genre = movieDTO.Genre,
                Grade = movieDTO.Grade,
            };

            await _context.Movies.AddAsync(movie);
            return movie;
        }


        //Delete movie from the database
        //If You delete a movie, records with the movie will alse be deleted from the ActorMovie database
        public async Task<MethodResultDTO> DeleteMovieFromDb(int IdMovie)
        {
            Movie movie = _context.Movies.SingleOrDefault(x => x.IdMovie == IdMovie);

            var list = _context.ActorMovies.Where(x => x.IdMovie == IdMovie).ToList();

            foreach (var actorMovie in list)
            {
                _context.ActorMovies.Remove(actorMovie);
            }

            _context.Movies.Remove(movie);

            await _context.SaveChangesAsync();

            return new MethodResultDTO
            {
                HttpStatusCode = HttpStatusCode.OK,
                Message = "Deleted"
            };

        }


        //Get the list of all the movies
        public async Task<IEnumerable<Movie>> GetMovieList()
        {
            return await _context.Movies.Select(x => new Movie
            {
                IdMovie = x.IdMovie,
                Title = x.Title,
                Genre = x.Genre,
                Grade = x.Grade
            }).ToListAsync();
        }


        //Update Movie database
        public async Task<MethodResultDTO> UpdateMovie(MovieDTO movieDTO)
        {
            Movie movie = (from a in _context.Movies
                           where a.IdMovie == movieDTO.IdMovie
                           select a).FirstOrDefault();

            movie.Title = movieDTO.Title;
            movie.Genre = movieDTO.Genre;
            movie.Grade = movieDTO.Grade;

            _context.Update(movie);

            await _context.SaveChangesAsync();

            return new MethodResultDTO
            {
                HttpStatusCode = HttpStatusCode.OK,
                Message = "Updated"
            };
        }
    }
}
