using Conduit.Users.Core;
using Conduit.Users.Interface;
using FluentAssertions;
using Xunit;

namespace Conduit.Users.Tests;

public class UserTests
{
    private readonly IUsersComponent _users;

    public UserTests()
    {
        _users = new UsersComponent();
    }

    [Fact]
    public void RegisterUser_ReturnsLoggedInUser()
    {
        // Arrange
        var command = new RegisterUserCommand("testyMcTestface", "testy@example.com", "testypassword");
        
        // Act
        var user = _users.Register(command);
        
        // Assert
        user.Username.Should().Be(command.Username);
        user.Email.Should().Be(command.Email);
        user.Token.Should().NotBeNullOrEmpty();
    }
}