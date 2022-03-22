using Conduit.Users.Interface;

namespace Conduit.Users.Core;

public class UsersComponent : IUsersComponent
{
    public User Register(RegisterUserCommand command)
    {
        var (username, email, _) = command;
        return new User(email, "a jwt token", username, "", null);
    }
}