using ErrorOr;

namespace BuberDinner.Application.Services.Authentication;

public interface IAuthenticationService
{
    public ErrorOr<AuthenticationResult> Login(string email, string password);
    public ErrorOr<AuthenticationResult> Register(
        string firstName,
        string lastName,
        string email,
        string password);
}