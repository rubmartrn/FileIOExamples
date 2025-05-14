using Microsoft.AspNetCore.Mvc;
using Netflix.MovieCatalog.Business;
using Netflix.MovieCatalog.Data.Entities;

namespace Netflix.MovieCatalog.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MovieController(IMovieService service) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetAllMovies(CancellationToken token)
        {
            var movies = await service.GetAllMoviesAsync(token);
            return Ok(movies);
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] Movie movie, CancellationToken token)
        {
            await service.Add(movie, token);
            return Ok();
        }
    }
}
