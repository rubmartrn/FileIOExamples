





namespace Netflix.User.Api.Services
{
    public interface IUserService
    {
        Task Add(UserManagement.Data.Entities.User user, CancellationToken token);
        Task<List<UserManagement.Data.Entities.User>> GetAllUsersAsync(CancellationToken token);
    }
}