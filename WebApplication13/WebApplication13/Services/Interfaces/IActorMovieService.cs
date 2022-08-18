using System.Collections.Generic;
using System.Threading.Tasks;
using WebApplication13.DTOs;
using WebApplication13.Entities;

namespace WebApplication13.Services.Interfaces
{
    public interface IActorMovieService
    {
        public Task<IEnumerable<ActorMovieDTO>> GetActorMovieList();

        public Task<MethodResultDTO> AddActorMovie(ActorMovieDTO actorMovieDTO);

        public Task<MethodResultDTO> DeleteActorMovieFromDb(int IdActorMovie);
    }
}
