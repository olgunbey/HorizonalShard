// See https://aka.ms/new-console-template for more information
using Microsoft.EntityFrameworkCore;
using Shard;
using Shard.Entities;


static async Task AddUserToShardAsync(User user)
{
    ShardService shardService = new ShardService();
    int resultId = shardService.IdConverter(user.Id);

    DbContext? dbContext = shardService.ShardSelection(resultId);
    dbContext?.Add(user);

    await dbContext.SaveChangesAsync();


}



//User user = new User()
//{
//    Id = Guid.NewGuid(),
//    FirstName = "ercan",
//    LastName = "arda"
//};
//await AddUserToShardAsync(user);

UserService userService = new UserService();
var user = await userService.GetUserByIdAsync(Guid.Parse("cd5dc759-966d-417e-9fe3-e53e74720264"));


Console.WriteLine(user!.FirstName);


