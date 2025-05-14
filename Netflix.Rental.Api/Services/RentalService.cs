using Microsoft.EntityFrameworkCore;
using Netflix.Rental.Data;

namespace Netflix.Rental.Api.Services
{
    public class RentalService(RentalDbContext context) : IRentalService
    {
        public async Task<List<Data.Entities.Rental>> GetAllRentalsAsync(CancellationToken token)
        {
            return await context.Rentals.ToListAsync(token);
        }

        public async Task Add(Data.Entities.Rental rental, CancellationToken token)
        {
            await context.Rentals.AddAsync(rental, token);
            await context.SaveChangesAsync(token);
        }
    }
}
