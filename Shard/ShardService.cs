using Microsoft.EntityFrameworkCore;

namespace Shard
{
    public class ShardService
    {
        public DbContext? ShardSelection(int userGuidId)
        {
            Dictionary<int, DbContext> dbContexts = new Dictionary<int, DbContext>()
            {
                {0,new UserDbContext() },
                {1,new UserShard1DbContext() }
            };
            dbContexts.TryGetValue(userGuidId % dbContexts.Count, out DbContext? dbContext);
            return dbContext;
        }
        public int IdConverter(Guid userId)
        {
            char firstChar = userId.ToString()[0];
            int result = 0;
            if (!int.TryParse(firstChar.ToString(), out result))
            {
                result = (int)firstChar;
            }
            return result;
        }
    }
}
