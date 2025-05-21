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

        public async Task<UserManagement.Data.Entities.User?> GetUserByIdAsync(int id, CancellationToken token)
        {
            return await context.Users.FirstOrDefaultAsync(e => e.Id == id, token);
        }

        public async Task Pay(int userId, decimal money, CancellationToken token)
        {
            var user = await context.Users.FirstOrDefaultAsync(e => e.Id == userId, token);
            if (user == null)
            {
                throw new Exception($"User with ID {userId} not found.");
            }
            user.Money -= money;
            context.Users.Update(user);
            await context.SaveChangesAsync(token);
        }

        public async Task Delete(int id, CancellationToken token)
        {
            var user = await context.Users.FirstOrDefaultAsync(e => e.Id == id, token);
            if (user == null)
            {
                throw new Exception($"User with ID {id} not found.");
            }
            context.Users.Remove(user);
            await context.SaveChangesAsync(token);
        }
    }
}
