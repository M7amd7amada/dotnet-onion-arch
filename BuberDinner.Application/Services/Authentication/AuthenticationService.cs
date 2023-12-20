using System.Runtime.CompilerServices;
using BuberDinner.Application.Common.Interfaces.Authentication;
using BuberDinner.Application.Common.Interfaces.Persistence;
using BuberDinner.Domain.Entities;

namespace BuberDinner.Application.Services.Authentication;

public class AuthenticationService(IJwtTokenGenerator tokenGenerator, IUserRepository userRepository) : IAuthenticationService
{
    private readonly IJwtTokenGenerator _tokenGenerator = tokenGenerator;
    private readonly IUserRepository _userRepository = userRepository;

    public AuthenticationResult Login(string email, string password)
    {
        if (_userRepository.GetUserByEmail(email) is not User user)
        {
            throw new Exception("User with given email doesn't exist");
        }

        if (user.Password != password)
        {
            throw new Exception("Invalid Password");
        }

        var token = _tokenGenerator.GenerateToken(user);


        return new()
        {
            User = user,
            Token = token
        };
    }

    public AuthenticationResult Register(
        string firstName,
        string lastName,
        string email,
        string password)
    {
        if (_userRepository.GetUserByEmail(email) is not null)
        {
            throw new Exception("User With given email already exist.");
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

        return new()
        {
            User = user,
            Token = token
        };
    }
}