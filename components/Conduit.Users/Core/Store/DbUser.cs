using Conduit.Users.Interface;

namespace Conduit.Users.Core.Store;

public record DbUser(
    string Email,
    string Password,
    string Username,
    string Bio,
    string? Image)
{
    public User AsLoggedInUser() => new(Email, "some jwt token", Username, Bio, Image);
};