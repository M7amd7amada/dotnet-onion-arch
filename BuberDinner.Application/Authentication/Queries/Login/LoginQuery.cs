using BuberDinner.Application.Authentication.Common;
using ErrorOr;
using MediatR;

namespace BuberDinner.Application.Authentication.Queries.Login;

public record LoginQuery : IRequest<ErrorOr<AuthenticationResult>>
{
    public string Email { get; set; } = default!;
    public string Password { get; set; } = default!;
}