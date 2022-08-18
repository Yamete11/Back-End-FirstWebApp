using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using WebApplication13.Context;
using WebApplication13.DTOs;
using WebApplication13.Entities;

using WebApplication13.Services.Interfaces;

namespace WebApplication13.Services.Implementations
{
    public class ActorMovieService : IActorMovieService
    {
        readonly MyDbContext _context;

        public ActorMovieService(MyDbContext context)
        {
            _context = context;
        }

        public async Task<MethodResultDTO> AddActorMovie(ActorMovieDTO actorMovieDTO)
        {
            IDbContextTransaction transaction = await _context.Database.BeginTransactionAsync();


            int newId = !await _context.ActorMovies.AnyAsync() ? 1 : await _context.ActorMovies.MaxAsync(x => x.IdActorMovie) + 1;

            int IdMovie = (from a in _context.Movies
                           where a.Title == actorMovieDTO.Title
                           select a.IdMovie).First();

            int IdActor = (from a in _context.Actors
                           where a.Nickname == actorMovieDTO.Nickname
                           select a.IdActor).First();



            ActorMovie actorMovie = new ActorMovie
            {
                IdActorMovie = newId,
                IdMovie = IdMovie,
                IdActor = IdActor,
                CharacterName = actorMovieDTO.Nickname,
            };

            await _context.ActorMovies.AddAsync(actorMovie);

            await _context.SaveChangesAsync();

            await transaction.CommitAsync();

            return new MethodResultDTO
            {
                HttpStatusCode = HttpStatusCode.OK,
                Message = "Added"
            };

        }

        public async Task<MethodResultDTO> DeleteActorMovieFromDb(int IdActorMovie)
        {
            ActorMovie actorMovie = _context.ActorMovies.SingleOrDefault(x => x.IdActorMovie == IdActorMovie);

            _context.ActorMovies.Remove(actorMovie);

            await _context.SaveChangesAsync();

            return new MethodResultDTO
            {
                HttpStatusCode = HttpStatusCode.OK,
                Message = "Deleted"
            };
        }

        public async Task<IEnumerable<ActorMovieDTO>> GetActorMovieList()
        {
            var list = await (from a in _context.Actors
                              join b in _context.ActorMovies on a.IdActor equals b.IdActor
                              join c in _context.Movies on b.IdMovie equals c.IdMovie
                              select new ActorMovieDTO
                              {
                                  IdActorMovie = b.IdActorMovie,
                                  Title = c.Title,
                                  Nickname = a.Nickname,
                                  CharacterName = b.CharacterName
                              }).ToListAsync();
            return list;

        }
    }
}
