using Microsoft.EntityFrameworkCore;
using Netflix.UserManagement.Data;

namespace Netflix.User.Api.Services
{
    public class UserService(UserDbContext context) : IUserService
    {
        public async Task<List<UserManagement.Data.Entities.User>> GetAllUsersAsync(CancellationToken token)
        {
            return await context.Users.ToListAsync(token);
        }

        public async Task Add(UserManagement.Data.Entities.User user, CancellationToken token)
        {
            await context.Users.AddAsync(user, token);
            await context.SaveChangesAsync(token);
        }
    }
}
