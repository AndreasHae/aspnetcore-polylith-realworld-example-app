using Conduit.Common;
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

    public void AddSession(DbSession session)
    {
        _context.Sessions.Add(session);
        _context.SaveChanges();
    }

    public DbUser Get(string email)
    {
        var user = _context.Users.FirstOrDefault(user => user.Email == email);
        if (user is null) throw new NotFoundException(nameof(DbUser));
        return user;
    }

    public DbUser GetByToken(string token)
    {
        var session = _context.Sessions.FirstOrDefault(session => session.Token == token);
        if (session is null) throw new SessionNotFoundException();
        
        return _context.Users.First(user => user.Email == session.UserEmail);
    }
}