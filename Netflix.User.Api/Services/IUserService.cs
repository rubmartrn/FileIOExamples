namespace Netflix.User.Api.Services
{
    public interface IUserService
    {
        Task Add(UserManagement.Data.Entities.User user, CancellationToken token);
        Task<List<UserManagement.Data.Entities.User>> GetAllUsersAsync(CancellationToken token);
        Task<UserManagement.Data.Entities.User?> GetUserByIdAsync(int id, CancellationToken token);
        Task Pay(int userId, decimal money, CancellationToken token);
        Task Delete(int id, CancellationToken token);
    }
}