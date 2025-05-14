using Microsoft.AspNetCore.Mvc;
using Netflix.Rental.Api.Services;
using Netflix.Rental.Data;

namespace Netflix.Rental.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RentalController(IRentalService service) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetAllRentals(CancellationToken token)
        {
            var rentals = await service.GetAllRentalsAsync(token);
            return Ok(rentals);
        }
    }
}
