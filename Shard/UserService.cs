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
    }
}
