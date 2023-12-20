using BuberDinner.Application.Services.Authentication;
using BuberDinner.Contracts.Authentication;
using Microsoft.AspNetCore.Mvc;

namespace BuberDinner.Api.Controllers;

[Route("api/auth/[action]")]
public class AuthenticationController(IAuthenticationService authService) : BaseController
{
    private readonly IAuthenticationService _authService = authService;

    [HttpPost]
    public IActionResult Login(LoginRequest request)
    {
        var authResult = _authService.Login(request.Email, request.Password);

        var authResponse = new AuthenticationResponse()
        {
            Id = authResult.User.Id,
            FirstName = authResult.User.FirstName,
            LastName = authResult.User.LastName,
            Email = authResult.User.Email,
            Token = authResult.Token
        };

        return Ok(authResponse);
    }

    [HttpPost]
    public IActionResult Register(RegisterRequest request)
    {
        var authResult = _authService.Register(
            request.FirstName,
            request.LastName,
            request.Email,
            request.Password);

        var authResponse = new AuthenticationResponse()
        {
            Id = authResult.User.Id,
            FirstName = authResult.User.FirstName,
            LastName = authResult.User.LastName,
            Email = authResult.User.Email,
            Token = authResult.Token
        };

        return Ok(authResponse);
    }
}