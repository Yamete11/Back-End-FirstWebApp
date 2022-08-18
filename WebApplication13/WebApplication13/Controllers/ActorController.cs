using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebApplication13.DTOs;
using WebApplication13.Entities;
using WebApplication13.Services.Interfaces;

namespace WebApplication13.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ActorController : ControllerBase
    {
        readonly IActorService _service;

        public ActorController(IActorService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IEnumerable<Actor>> Get()
        {
            var actor = await _service.GetActorList();
            return actor;
        }


        [HttpPost]
        public async Task<IActionResult> AddActor(ActorDTO actor)
        {
            MethodResultDTO methodResult = await _service.AddActor(actor);
            return StatusCode((int)methodResult.HttpStatusCode, methodResult.Message);
        }

        [HttpDelete("{IdActor}")]
        public async Task<ActionResult> DeleteActor(int IdActor)
        {
            MethodResultDTO methodResult = await _service.DeleteActorFromDb(IdActor);
            return StatusCode((int)methodResult.HttpStatusCode, methodResult.Message);
        }

        [HttpPut]
        public async Task<ActionResult> UpdateActor(ActorDTO actorDTO)
        {
            MethodResultDTO methodResult = await _service.UpdateActor(actorDTO);
            return StatusCode((int)methodResult.HttpStatusCode, methodResult.Message);
        }
    }
}
