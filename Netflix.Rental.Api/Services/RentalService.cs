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

        public async Task DeleteByUser(int userId, CancellationToken token)
        {
            var rentals = await context.Rentals.Where(e => e.UserId == userId).ToListAsync(token);
            if (rentals.Count == 0)
            {
                return;
            }
            context.Rentals.RemoveRange(rentals);
            await context.SaveChangesAsync(token);
        }

        public async Task DeleteByMovie(int movieId, CancellationToken token)
        {
            var rentals = await context.Rentals.Where(e => e.MovieId == movieId).ToListAsync(token);
            if (rentals.Count == 0)
            {
                return;
            }
            context.Rentals.RemoveRange(rentals);
            await context.SaveChangesAsync(token);
        }
    }
}
