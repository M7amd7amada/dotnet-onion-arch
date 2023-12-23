using BuberDinner.Application.Common.Interfaces.Authentication;
using BuberDinner.Application.Common.Interfaces.Persistence;
using BuberDinner.Application.Authentication.Common;
using BuberDinner.Domain.Entities;
using BuberDinner.Domain.Common.Errors;
using ErrorOr;
using MediatR;

namespace BuberDinner.Application.Authentication.Commands.Register;

public class RegisterCommandHandler(IJwtTokenGenerator tokenGenerator, IUserRepository userRepository)
        : IRequestHandler<RegisterCommand, ErrorOr<AuthenticationResult>>
{
    private readonly IJwtTokenGenerator _tokenGenerator = tokenGenerator;
    private readonly IUserRepository _userRepository = userRepository;

#pragma warning disable CS1998 // Async method lacks 'await' operators and will run synchronously
    public async Task<ErrorOr<AuthenticationResult>> Handle(
#pragma warning restore CS1998 // Async method lacks 'await' operators and will run synchronously
        RegisterCommand command,
        CancellationToken cancellationToken)
    {
        if (_userRepository.GetUserByEmail(command.Email) is not null)
        {
            return Errors.User.DuplicateEmail;
        }

        var user = new User()
        {
            FirstName = command.FirstName,
            LastName = command.LastName,
            Email = command.Email,
            Password = command.Password
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