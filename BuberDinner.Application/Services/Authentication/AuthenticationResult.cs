using BuberDinner.Domain.Entities;

namespace BuberDinner.Application.Services.Authentication;

public record AuthenticationResult
{
    public User User { get; set; } = default!;
    public string Token { get; set; } = default!;
}