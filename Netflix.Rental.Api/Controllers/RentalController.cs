using Microsoft.AspNetCore.Mvc;
using Netflix.Rental.Api.Clients;
using Netflix.Rental.Api.Services;
using Netflix.Rental.Data;

namespace Netflix.Rental.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RentalController(IRentalService service, MovieApi movieApi, UserApi userApi) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetAllRentals(CancellationToken token)
        {
            var rentals = await service.GetAllRentalsAsync(token);
            return Ok(rentals);
        }

        [HttpGet("rent")]
        public async Task<IActionResult> RentMovie([FromQuery] int userId, [FromQuery] int movieId, CancellationToken token)
        {
            var movie = await movieApi.GetMovieById(movieId, token);
            if (movie == null)
            {
                return NotFound($"Movie with ID {movieId} not found.");
            }
            if (movie.Amount <= 0)
            {
                return BadRequest($"Movie with ID {movieId} is not available for rent.");
            }

            var user = await userApi.GetById(userId, token);

            if (user == null)
            {
                return NotFound($"User with ID {userId} not found.");
            }


            if (user.Money < movie.Price)
            {
               return BadRequest($"User with ID {userId} does not have enough money to rent the movie.");
            }

            await movieApi.RentMovie(movieId, token);
            await userApi.Pay(userId, movie.Price, token);
            var rental = new Data.Entities.Rental { UserId = userId, MovieId = movieId };
            await service.Add(rental, token);
            return Ok();
        }
    }
}
