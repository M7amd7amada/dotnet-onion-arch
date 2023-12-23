using BuberDinner.Application.Services.Authentication;
using BuberDinner.Contracts.Authentication;
using ErrorOr;
using Microsoft.AspNetCore.Mvc;

namespace BuberDinner.Api.Controllers;

[Route("api/auth/[action]")]
public class AuthenticationController(IAuthenticationService authService) : ApiController
{
    private readonly IAuthenticationService _authService = authService;

    [HttpPost]
    public IActionResult Login(LoginRequest request)
    {
        var authResult = _authService.Login(request.Email, request.Password);

        return authResult.Match(
            authResult => Ok(MapAuthResponse(authResult)),
            Problem
        );
    }

    [HttpPost]
    public IActionResult Register(RegisterRequest request)
    {
        ErrorOr<AuthenticationResult> authResult = _authService.Register(
            request.FirstName,
            request.LastName,
            request.Email,
            request.Password);

        return authResult.Match(
            authResult => Ok(MapAuthResponse(authResult)),
            Problem
        );
    }

    private static AuthenticationResponse MapAuthResponse(AuthenticationResult authResult)
    {
        return new AuthenticationResponse()
        {
            Id = authResult.User.Id,
            FirstName = authResult.User.FirstName,
            LastName = authResult.User.LastName,
            Email = authResult.User.Email,
            Token = authResult.Token
        };
    }
}