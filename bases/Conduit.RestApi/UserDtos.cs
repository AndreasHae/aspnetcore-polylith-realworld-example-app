using Conduit.Users.Interface;

namespace Conduit.RestApi;

record RegisterUserRequest(RegisterUserCommand User);

record UserResponse(User User);