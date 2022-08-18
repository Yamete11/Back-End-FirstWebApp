using System.Collections.Generic;
using System.Threading.Tasks;
using WebApplication13.DTOs;
using WebApplication13.Entities;
namespace WebApplication13.Services
{
    public interface IMovieService
    {
        public Task<IEnumerable<Movie>> GetMovieList();
        public Task<MethodResultDTO> AddMovie(MovieDTO movie);

        public Task<MethodResultDTO> DeleteMovieFromDb(int IdMovie);

        public Task<MethodResultDTO> UpdateMovie(MovieDTO movieDTO);
    }
}