namespace Conduit.Users.Interface;

public interface IUsersComponent
{
    User Register(RegisterUserCommand command);
    User Login(LoginUserCommand command);
}

public record RegisterUserCommand(
    string Username,
    string Email,
    string Password);

public record LoginUserCommand(string Email, string Password);

public record User(
    string Email,
    string Token,
    string Username,
    string Bio,
    string? Image);