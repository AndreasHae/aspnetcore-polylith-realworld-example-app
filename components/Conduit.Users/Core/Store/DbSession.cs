namespace Conduit.Users.Core.Store;

public record DbSession(
    string Token,
    string UserEmail);