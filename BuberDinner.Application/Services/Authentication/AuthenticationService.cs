using BuberDinner.Application.Common.Interfaces.Authentication;
using BuberDinner.Application.Common.Interfaces.Persistence;
using BuberDinner.Domain.Common.Errors;
using BuberDinner.Domain.Entities;
using ErrorOr;

namespace BuberDinner.Application.Services.Authentication;

public class AuthenticationService(
    IJwtTokenGenerator tokenGenerator,
    IUserRepository userRepository) : IAuthenticationService
{
    private readonly IJwtTokenGenerator _tokenGenerator = tokenGenerator;
    private readonly IUserRepository _userRepository = userRepository;

    public ErrorOr<AuthenticationResult> Login(string email, string password)
    {
        if (_userRepository.GetUserByEmail(email) is not User user)
        {
            return Errors.Authentication.InvalidCredentials;
        }

        if (user.Password != password)
        {
            return Errors.Authentication.InvalidCredentials;
        }

        var token = _tokenGenerator.GenerateToken(user);

        return new AuthenticationResult()
        {
            User = user,
            Token = token
        };
    }

    public ErrorOr<AuthenticationResult> Register(
        string firstName,
        string lastName,
        string email,
        string password)
    {
        if (_userRepository.GetUserByEmail(email) is not null)
        {
            return Errors.User.DuplicateEmail;
        }

        var user = new User()
        {
            FirstName = firstName,
            LastName = lastName,
            Email = email,
            Password = password
        };

        _userRepository.Add(user);

        var token = _tokenGenerator.GenerateToken(user);

        return new AuthenticationResult()
        {
            User = user,
            Token = token
        };
    }
}