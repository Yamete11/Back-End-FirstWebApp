using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
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
    public class ActorService : IActorService
    {
        readonly MyDbContext _context;

        public ActorService(MyDbContext context)
        {
            _context = context;
        }

        public async Task<MethodResultDTO> AddActor(ActorDTO actor)
        {
            IDbContextTransaction transaction = await _context.Database.BeginTransactionAsync();

            Actor ActorName = _context.Actors.SingleOrDefault(x => x.Name.Trim().ToLower() == actor.Name.Trim().ToLower());

            if(ActorName != null)
            {
                transaction.Rollback();

                return new MethodResultDTO
                {
                    HttpStatusCode = HttpStatusCode.Forbidden,
                    Message = "Actor already exists"
                };
            }

            await AddActorAsync(actor);

            await _context.SaveChangesAsync();

            await transaction.CommitAsync();

            return new MethodResultDTO
            {
                HttpStatusCode = HttpStatusCode.OK,
                Message = "Added"
            };

        }

        public async Task<Actor> AddActorAsync(ActorDTO actorDTO)
        {
            int newId = !await _context.Actors.AnyAsync() ? 1 : await _context.Actors.MaxAsync(x => x.IdActor) + 1;

            Actor actor = new Actor
            {
                IdActor = newId,
                Name = actorDTO.Name,
                Surname = actorDTO.Surname,
                Nickname = actorDTO.Nickname,
            };

            await _context.Actors.AddAsync(actor);
            return actor;
        }

        //If You delete an actor, records with the movie will alse be deleted from the ActorMovie database

        public async Task<MethodResultDTO> DeleteActorFromDb(int IdActor)
        {
            Actor actor = _context.Actors.SingleOrDefault(x => x.IdActor == IdActor);

            var list = _context.ActorMovies.Where(x => x.IdActor == IdActor).ToList();

            foreach(var actorMovie in list)
            {
                _context.ActorMovies.Remove(actorMovie);
            }

            _context.Actors.Remove(actor);

            await _context.SaveChangesAsync();

            return new MethodResultDTO
            {
                HttpStatusCode = HttpStatusCode.OK,
                Message = "Deleted"
            };
        }

        public async Task<IEnumerable<Actor>> GetActorList()
        {
            return await _context.Actors.Select(x => new Actor
            {
                IdActor = x.IdActor,
                Name = x.Name,
                Surname = x.Surname,
                Nickname = x.Nickname,
            }).ToListAsync();
        }

        public async Task<MethodResultDTO> UpdateActor(ActorDTO actorDTO)
        {
            

            Actor actor = (from a in _context.Actors
             where a.IdActor == actorDTO.IdActor
             select a).FirstOrDefault();

            actor.Name = actorDTO.Name;
            actor.Surname = actorDTO.Surname;
            actor.Nickname = actorDTO.Nickname;

            _context.Update(actor);

            await _context.SaveChangesAsync();

            return new MethodResultDTO
            {
                HttpStatusCode = HttpStatusCode.OK,
                Message = "Updated"
            };
        }
    }
}
