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
        var userContext = new UserContext(
            new DbContextOptionsBuilder<UserContext>()
                .UseInMemoryDatabase("users_tests")
                .Options);
        userContext.Users.RemoveRange(userContext.Users);
        _users = new UsersComponent(new DbUserRepository(userContext));
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

    [Fact]
    public void Login_WithWrongPassword_ThrowsWrongPasswordException()
    {
        // Arrange
        var email = "testy@example.com";
        _users.Register(new RegisterUserCommand("testy", email, "testysPassword"));

        // Act
        var login = () => { _users.Login(new LoginUserCommand(email, "notTestysPassword")); };

        // Assert
        login.Should().Throw<WrongPasswordException>();
    }

    [Fact]
    public void GetCurrent_WithValidToken_ReturnsCurrentUser()
    {
        // Arrange
        var expectedUser = _users.Register(new RegisterUserCommand("testy", "testy@example.com", "testypass"));

        // Act
        var user = _users.GetCurrent(expectedUser.Token);

        // Assert
        user.Should().BeEquivalentTo(expectedUser);
    }
}