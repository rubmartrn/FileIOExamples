using Microsoft.EntityFrameworkCore;
using Netflix.User.Api.Clients;
using Netflix.UserManagement.Data;

namespace Netflix.User.Api.Services
{
    public class UserService(UserDbContext context, RentClient client) : IUserService
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
            using var transaction2 = await context.Database.BeginTransactionAsync(token);

            var user = await context.Users.FirstOrDefaultAsync(e => e.Id == userId, token);
            if (user == null)
            {
                throw new Exception($"User with ID {userId} not found.");
            }
            user.Money -= money;
            context.Users.Update(user);
            var user1 = await context.Users.FirstOrDefaultAsync(e => e.Id == userId, token);

            await context.SaveChangesAsync(token);
        }

        public async Task Delete(int id, CancellationToken token)
        {
            using var transaction1 = await context.Database.BeginTransactionAsync(token);
            try
            {
                var user = await context.Users.FirstOrDefaultAsync(e => e.Id == id, token);
                user.UserName = "Deleted User"; // soft delete
                //context.Users.Remove(user);
                await context.SaveChangesAsync(token);// uncommitted changes
                transaction1.Commit();// commit changes to the database
            }
            catch (Exception ex)
            {
                transaction1.Rollback();
            }
        }
    }
}
