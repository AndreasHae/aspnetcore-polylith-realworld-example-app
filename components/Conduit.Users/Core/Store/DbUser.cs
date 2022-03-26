using Conduit.Users.Interface;

namespace Conduit.Users.Core.Store;

public record DbUser(
    string Email,
    string Password,
    string Username,
    string Bio,
    string? Image)
{
    public User AsLoggedInUser(string token) => new(Email, token, Username, Bio, Image);
};