using Conduit.Users.Core.Store;

namespace Conduit.Users.Core;

public interface IUserRepository
{
    void Save(DbUser newUser);
    void AddSession(DbSession session);
    DbUser Get(string email);
    DbUser GetByToken(string token);
}