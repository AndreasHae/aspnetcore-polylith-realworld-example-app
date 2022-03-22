using Conduit.Users.Interface;

namespace Conduit.Users.Core.Store;

public class DbUserRepository : IUserRepository
{
    private readonly UserContext _context;

    public DbUserRepository(UserContext context)
    {
        _context = context;
    }

    public void Save(DbUser newUser)
    {
        _context.Users.Add(newUser);
        _context.SaveChanges();
    }

    public User? Get(string email, string password)
    {
        return _context.Users
            .FirstOrDefault(user => user.Email == email && user.Password == password)
            ?.AsLoggedInUser();
    }
}

public record DbUser(
    string Email,
    string Password,
    string Username,
    string Bio,
    string? Image)
{
    public User AsLoggedInUser() => new(Email, "some jwt token", Username, Bio, Image);
};