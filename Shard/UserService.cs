using Microsoft.EntityFrameworkCore;
using Shard.Entities;

namespace Shard
{
    public class UserService
    {
        public async ValueTask<User?> GetUserByIdAsync(Guid userId)
        {
            ShardService shardService = new ShardService();
            int resultId = shardService.IdConverter(userId);
            DbContext? dbContext = shardService.ShardSelection(resultId);
            var hasUser = await dbContext!.Set<User>().FindAsync(userId);
            if (hasUser == null)
            {
                return null;
            }
            return hasUser;
        }
        public async Task AddUser(User user)
        {
            ShardService shardService = new ShardService();
            int resultId = shardService.IdConverter(user.Id);
            DbContext? dbContext = shardService.ShardSelection(resultId);
            dbContext!.Add(user);
            await dbContext!.SaveChangesAsync();
        }
    }
}
