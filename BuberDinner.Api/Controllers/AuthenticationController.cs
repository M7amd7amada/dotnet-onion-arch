using BuberDinner.Application.Authentication.Commands.Register;
using BuberDinner.Application.Authentication.Common;
using BuberDinner.Application.Authentication.Queries.Login;
using BuberDinner.Contracts.Authentication;
using BuberDinner.Domain.Common.Errors;
using ErrorOr;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace BuberDinner.Api.Controllers;

[Route("api/auth/[action]")]
public class AuthenticationController(
    ISender mediator) : ApiController
{
    private readonly ISender _mediator = mediator;

    [HttpPost]
    public async Task<IActionResult> LoginAsync(LoginRequest request)
    {
        var query = new LoginQuery
        {
            Email = request.Email,
            Password = request.Password
        };

        ErrorOr<AuthenticationResult> authResult = await _mediator.Send(query);

        if (authResult.IsError && authResult.FirstError == Errors.Authentication.InvalidCredentials)
        {
            return Problem(
                statusCode: StatusCodes.Status401Unauthorized,
                title: authResult.FirstError.Description
            );
        }

        return authResult.Match(
            authResult => Ok(MapAuthResponse(authResult)),
            Problem
        );
    }

    [HttpPost]
    public async Task<IActionResult> Register(RegisterRequest request)
    {
        var command = new RegisterCommand
        {
            FirstName = request.FirstName,
            LastName = request.LastName,
            Email = request.Email,
            Password = request.Password
        };

        ErrorOr<AuthenticationResult> authResult = await _mediator.Send(command);

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