using Conduit.Users.Core;
using Conduit.Users.Core.Store;
using Conduit.Users.Interface;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace Conduit.Users.Tests;

public class UserTests
{
    private readonly IUsersComponent _users;

    public UserTests()
    {
        _users = new UsersComponent(new DbUserRepository(new UserContext(new DbContextOptionsBuilder<UserContext>()
            .UseInMemoryDatabase("users_tests")
            .Options)));
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

    [Fact]
    public void Login_WithCorrectPassword_ReturnsLoggedInUser()
    {
        // Arrange
        var username = "testy";
        var email = "testy@example.com";
        var password = "testypassword";
        _users.Register(new RegisterUserCommand(username, email, password));

        // Act
        var user = _users.Login(new LoginUserCommand(email, password));

        // Assert
        user.Username.Should().Be(username);
        user.Email.Should().Be(email);
        user.Token.Should().NotBeNullOrEmpty();
    }
}