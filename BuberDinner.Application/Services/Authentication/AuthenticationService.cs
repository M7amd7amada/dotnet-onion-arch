using BuberDinner.Application.Common.Interfaces.Authentication;

namespace BuberDinner.Application.Services.Authentication;

public class AuthenticationService(IJwtTokenGenerator tokenGenerator) : IAuthenticationService
{
    private readonly IJwtTokenGenerator _tokenGenerator = tokenGenerator;

    public AuthenticationResult Login(string email, string password)
    {
        return new()
        {
            Id = Guid.NewGuid(),
            FirstName = "firstName",
            LastName = "lastName",
            Email = email,
            Token = "token"
        };
    }

    public AuthenticationResult Register(
        string firstName,
        string lastName,
        string email,
        string password)
    {
        var userId = Guid.NewGuid();
        var token = _tokenGenerator.GenerateToken(userId, firstName, lastName);

        return new()
        {
            Id = userId,
            FirstName = firstName,
            LastName = lastName,
            Email = email,
            Token = token
        };
    }
}