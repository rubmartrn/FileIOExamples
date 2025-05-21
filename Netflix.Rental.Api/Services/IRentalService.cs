
namespace Netflix.Rental.Api.Services
{
    public interface IRentalService
    {
        Task Add(Data.Entities.Rental rental, CancellationToken token);
        Task<List<Data.Entities.Rental>> GetAllRentalsAsync(CancellationToken token);
        Task DeleteByUser(int userId, CancellationToken token);
        Task DeleteByMovie(int movieId, CancellationToken token);
    }
}