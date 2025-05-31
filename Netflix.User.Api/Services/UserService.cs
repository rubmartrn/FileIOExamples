using Microsoft.EntityFrameworkCore;
using Netflix.User.Api.Clients;
using Netflix.UserManagement.Data;
using System.Data;

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


        public void BeforeCommit()
        {
            using var transaction = context.Database.BeginTransaction(IsolationLevel.ReadUncommitted);
            var user = context.Users.FirstOrDefault(e => e.Id == 1);//  եթե սեյվ ենք արել, բայց commit չենք արել, ապա այս հարցումը կվերադարձնի  Deleted User

            if (user.UserName == "Deleted User")
            {
                user.Money = 0;
            }

            using var transaction1 = context.Database.BeginTransaction(IsolationLevel.Chaos);
            var user1 = context.Users.FirstOrDefault(e => e.Id == 1);//  եթե սեյվ ենք արել, բայց commit չենք արել, ապա այս հարցումը կվերադարձնի Deleted User
            if (user.UserName == "Deleted User")
            {
                user.Money = 0;
            }//Exception: The operation failed because the transaction is in an uncommitted state.

            using var transaction2 = context.Database.BeginTransaction(IsolationLevel.ReadCommitted);
            var user2 = context.Users.FirstOrDefault(e => e.Id == 1);//  եթե սեյվ ենք արել, բայց commit չենք արել, ապա այս հարցումը կվերադարձնի իրական անունը
            //Commit արեցինք
            var user3 = context.Users.FirstOrDefault(e => e.Id == 1);//  name  = Deleted User
        }

        public void AfterCommit()
        {
            //Մինչև commit
            using var transaction = context.Database.BeginTransaction(IsolationLevel.RepeatableRead);
            var user = context.Users.FirstOrDefault(e => e.Id == 1);// user name = John

            //ուրիշ իրավիճակ
            var users = context.Users.Where(e => e.Id > 1).ToList();// 10 users

            if (user.UserName == "Deleted User")
            {
                user.UserName = "Restored User";
            }

            //Commit արեցինք
            var user1 = context.Users.FirstOrDefault(e => e.Id == 1);// user name = John


            //ուրիշ իրավիճակ
            var users1 = context.Users.Where(e => e.Id > 1).ToList();// 9 users
            context.SaveChanges();
            transaction.Commit();
        }

        public void AfterCommit1()
        {
            //Մինչև commit
            using var transaction = context.Database.BeginTransaction(IsolationLevel.Serializable);
            var user = context.Users.FirstOrDefault(e => e.Id == 1);// user name = John

            //ուրիշ իրավիճակ
            var users = context.Users.Where(e => e.Id > 1).ToList();// 10 users

            if (user.UserName == "Deleted User")
            {
                user.UserName = "Restored User";
            }

            //Commit արեցինք
            var user1 = context.Users.FirstOrDefault(e => e.Id == 1);// user name = John


            //ուրիշ իրավիճակ
            var users1 = context.Users.Where(e => e.Id > 1).ToList();// 10 users
            context.SaveChanges();
            transaction.Commit();
        }

        public void AfterCommit3()
        {
            //Մինչև commit
            using var transaction = context.Database.BeginTransaction(IsolationLevel.Snapshot);
            var user = context.Users.FirstOrDefault(e => e.Id == 1);// user name = John // RowVersion 1

            //ուրիշ իրավիճակ
            var users = context.Users.Where(e => e.Id > 1).ToList();// 10 users

            if (user.UserName == "Deleted User")
            {
                user.UserName = "Restored User";
            }

            //Commit արեցինք
            var user1 = context.Users.FirstOrDefault(e => e.Id == 1);// user name = John


            //ուրիշ իրավիճակ
            var users1 = context.Users.Where(e => e.Id > 1).ToList();// 10 users
            // RowVersion 2
            // thrw exception
            context.SaveChanges();
            transaction.Commit();
        }

        public async Task Pay(int userId, decimal money, CancellationToken token)
        {
            using var transaction2 = await context.Database.BeginTransactionAsync(token);

            var user = await context.Users.FirstOrDefaultAsync(e => e.Id == userId, token);
            var users = await context.Users.Where(e=>e.Id > 1).ToListAsync(token);// 10 users   
            if (user == null)
            {
                throw new Exception($"User with ID {userId} not found.");
            }
            user.Money -= money;
            context.Users.Update(user);

            var users1 = await context.Users.Where(e => e.Id > 1).ToListAsync(token);// 9 users   


            await context.SaveChangesAsync(token);
        }

        public async Task Delete(int id, CancellationToken token)
        {
            using var transaction1 = await context.Database.BeginTransactionAsync(token);
            try
            {
                var user = await context.Users.FirstOrDefaultAsync(e => e.Id == id, token);// Version =1

                user.UserName= "Deleted User";
                //context.Users.Remove(user);
                await context.SaveChangesAsync(token);// uncommitted changes
                transaction1.Commit();// commit changes to the database// Version =2
            }
            catch (Exception ex)
            {
                transaction1.Rollback();
            }
        }
    }
}
