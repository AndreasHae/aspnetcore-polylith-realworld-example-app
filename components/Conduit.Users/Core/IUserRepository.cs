using Conduit.Users.Core.Store;
using Conduit.Users.Interface;

namespace Conduit.Users.Core;

public interface IUserRepository
{
    void Save(DbUser newUser);
    User? Get(string email, string password);
}