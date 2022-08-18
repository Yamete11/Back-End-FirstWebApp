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
    public class ActorMovieController : ControllerBase
    {
        readonly IActorMovieService _service;

        public ActorMovieController(IActorMovieService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IEnumerable<ActorMovieDTO>> GetActorMovie()
        {
            var list = await _service.GetActorMovieList();
            return list;
        }

        [HttpPost]
        public async Task<IActionResult> AddActorMovie(ActorMovieDTO actor)
        {
            MethodResultDTO methodResult = await _service.AddActorMovie(actor);
            return StatusCode((int)methodResult.HttpStatusCode, methodResult.Message);
        }

        [HttpDelete("{IdActorMovie}")]
        public async Task<ActionResult> DeleteActorMovie(int IdActorMovie)
        {
            MethodResultDTO methodResult = await _service.DeleteActorMovieFromDb(IdActorMovie);
            return StatusCode((int)methodResult.HttpStatusCode, methodResult.Message);
        }
    }
}
