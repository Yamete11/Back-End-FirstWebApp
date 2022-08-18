using System.Collections.Generic;
using System.Threading.Tasks;
using WebApplication13.DTOs;
using WebApplication13.Entities;

namespace WebApplication13.Services.Interfaces
{
    public interface IActorService
    {
        public Task<IEnumerable<Actor>> GetActorList();
        public Task<MethodResultDTO> AddActor(ActorDTO actor);

        public Task<MethodResultDTO> DeleteActorFromDb(int IdActor);

        public Task<MethodResultDTO> UpdateActor(ActorDTO actorDTO);

    }
}
