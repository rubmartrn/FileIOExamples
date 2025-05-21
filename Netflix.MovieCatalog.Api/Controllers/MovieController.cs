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

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetMovieById([FromRoute] int id, CancellationToken token)
        {
            var movie = await service.GetMovieByIdAsync(id, token);
            if (movie == null)
            {
                return NotFound();
            }
            return Ok(movie);
        }

        [HttpGet("rent")]
        public async Task<IActionResult> RentMovie([FromQuery] int movieId, CancellationToken token)
        {
            await service.RentMovie(movieId, token);
            return Ok();
        }
    }
}
