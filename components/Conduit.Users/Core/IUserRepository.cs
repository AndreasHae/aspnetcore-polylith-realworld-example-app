using Conduit.Users.Core.Store;

namespace Conduit.Users.Core;

public interface IUserRepository
{
    void Save(DbUser newUser);
    DbUser Get(string email);
}