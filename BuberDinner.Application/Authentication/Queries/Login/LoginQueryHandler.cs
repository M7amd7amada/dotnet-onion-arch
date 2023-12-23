using BuberDinner.Application.Common.Interfaces.Authentication;
using BuberDinner.Application.Common.Interfaces.Persistence;
using BuberDinner.Application.Authentication.Common;
using BuberDinner.Domain.Common.Errors;
using BuberDinner.Domain.Entities;
using ErrorOr;
using MediatR;

namespace BuberDinner.Application.Authentication.Queries.Login;

public class LoginQueryHandler(
    IJwtTokenGenerator tokenGenerator,
    IUserRepository userRepository) : IRequestHandler<LoginQuery, ErrorOr<AuthenticationResult>>
{
    private readonly IJwtTokenGenerator _tokenGenerator = tokenGenerator;
    private readonly IUserRepository _userRepository = userRepository;

#pragma warning disable CS1998 // Async method lacks 'await' operators and will run synchronously
    public async Task<ErrorOr<AuthenticationResult>> Handle(
#pragma warning restore CS1998 // Async method lacks 'await' operators and will run synchronously
        LoginQuery query,
        CancellationToken cancellationToken)
    {

        if (_userRepository.GetUserByEmail(query.Email) is not User user)
        {
            return Errors.Authentication.InvalidCredentials;
        }

        if (user.Password != query.Password)
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
}