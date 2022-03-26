using Conduit.Users.Core.Store;
using Conduit.Users.Interface;

namespace Conduit.Users.Core;

public class UsersComponent : IUsersComponent
{
    private readonly IUserRepository _userRepository;

    public UsersComponent(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public User Register(RegisterUserCommand command)
    {
        var (username, email, password) = command;
        var newUser = new DbUser(email, password, username, "", null);
        _userRepository.Save(newUser);
        return newUser.AsLoggedInUser();
    }

    public User Login(LoginUserCommand command)
    {
        var (email, password) = command;
        
        var user = _userRepository.Get(email);
        if (user.Password != password) throw new WrongPasswordException();

        return user.AsLoggedInUser();
    }
}