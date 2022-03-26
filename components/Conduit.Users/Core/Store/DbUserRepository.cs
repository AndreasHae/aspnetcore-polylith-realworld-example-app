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

    public DbUser? Get(string email)
    {
        return _context.Users.FirstOrDefault(user => user.Email == email);
    }
}