using Conduit.Users.Interface;

namespace Conduit.RestApi;

record RegisterUserRequest(RegisterUserCommand User);

public record LoginUserRequest(
    LoginUserCommand User);

record UserResponse(User User);