using Microsoft.EntityFrameworkCore;
using Netflix.MovieCatalog.Data;
using Netflix.Rental.Data;

namespace Netflix.Rental.Jobs.BackgroundServices
{
    public class RentalService : BackgroundService
    {
        private readonly IServiceProvider _provider;

        public RentalService(IServiceProvider provider)
        {
            _provider = provider;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (true)
            {
                using var scope = _provider.CreateScope();
                var movieContext = scope.ServiceProvider.GetRequiredService<MovieDbContext>();
                var rentalContext = scope.ServiceProvider.GetRequiredService<RentalDbContext>();

                var outboxMessages = await movieContext.OutBoxes.Where(e => !e.Done).ToListAsync(stoppingToken);
                foreach (var outBoxMessage in outboxMessages)
                {
                    if (outBoxMessage.Type == MovieCatalog.Data.Enums.OutBoxType.MovieDeleted)
                    {
                        var movieId = int.Parse(outBoxMessage.Data);
                        var rentals = await rentalContext.Rentals.Where(e => e.MovieId == movieId).ToListAsync(stoppingToken);
                        if (rentals.Count > 0)
                        {
                            rentalContext.Rentals.RemoveRange(rentals);
                        }
                    }
                    outBoxMessage.Done = true;
                }

                await rentalContext.SaveChangesAsync(stoppingToken);
                await movieContext.SaveChangesAsync(stoppingToken);

                await DeleteOutboxMessages();
                await Task.Delay(5000, stoppingToken);
            }
        }

        private async Task DeleteOutboxMessages()
        {
            using var scope = _provider.CreateScope();
            var movieContext = scope.ServiceProvider.GetRequiredService<MovieDbContext>();
            var outboxMessages = await movieContext.OutBoxes.Where(e => e.Done && e.CreatedAt <= DateTime.UtcNow.AddDays(-30)).ToListAsync();
            if (outboxMessages.Count > 0)
            {
                movieContext.OutBoxes.RemoveRange(outboxMessages);
                await movieContext.SaveChangesAsync();
            }
        }
    }
}
