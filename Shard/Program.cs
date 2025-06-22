// See https://aka.ms/new-console-template for more information
using Microsoft.EntityFrameworkCore;
using Shard;
using Shard.Entities;


static async Task AddUserToShardAsync(User user)
{
    Dictionary<int, DbContext> dbContexts = new Dictionary<int, DbContext>()
    {
        {0,new UserDbContext() },
        {1,new UserShard1DbContext() }
    };

    char firstChar = user.Id.ToString()[0];

    int result = 0;

    if (!int.TryParse(firstChar.ToString(), out result))
    {
        result = (int)firstChar;
    }

    dbContexts.TryGetValue(result % dbContexts.Count, out DbContext dbContext);
    dbContext.Add(user);

    await dbContext.SaveChangesAsync();


}



User user = new User()
{
    Id = Guid.NewGuid(),
    FirstName = "ercan",
    LastName = "arda"
};
await AddUserToShardAsync(user);



