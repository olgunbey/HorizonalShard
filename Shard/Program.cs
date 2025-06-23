// See https://aka.ms/new-console-template for more information
using Shard;


UserService userService = new UserService();

await userService.AddUser(new Shard.Entities.User()
{
    Id = Guid.NewGuid(),
    FirstName = "Ahmet",
    LastName = "Hakan"
});
var user = await userService.GetUserByIdAsync(Guid.Parse("cd5dc759-966d-417e-9fe3-e53e74720264"));



