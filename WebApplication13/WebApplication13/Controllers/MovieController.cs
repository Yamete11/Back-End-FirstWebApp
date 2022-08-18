using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebApplication13.DTOs;
using WebApplication13.Entities;
using WebApplication13.Services;

namespace WebApplication13.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieController : ControllerBase
    {
        readonly IMovieService _service;

        public MovieController(IMovieService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IEnumerable<Movie>> Get()
        {
            var movie = await _service.GetMovieList();
            return movie;
        }


        [HttpPost]
        public async Task<IActionResult> AddMovie(MovieDTO movie)
        {
            MethodResultDTO methodResult = await _service.AddMovie(movie);
            return StatusCode((int)methodResult.HttpStatusCode, methodResult.Message);
        }

        [HttpDelete("{IdMovie}")]
        public async Task<ActionResult> DeleteMovie(int IdMovie)
        {
            MethodResultDTO methodResult = await _service.DeleteMovieFromDb(IdMovie);
            return StatusCode((int)methodResult.HttpStatusCode, methodResult.Message);
        }

        [HttpPut]
        public async Task<ActionResult> UpdateActor(MovieDTO movieDTO)
        {
            MethodResultDTO methodResult = await _service.UpdateMovie(movieDTO);
            return StatusCode((int)methodResult.HttpStatusCode, methodResult.Message);
        }

    }
}
