namespace BuberDinner.Infrastructure.Authentication;

public class JwtSettings
{
    public const string SectionName = nameof(JwtSettings);
    public string SecretKey { get; init; } = default!;
    public int ExpiryMinutes { get; init; }
    public string Issuer { get; init; } = default!;
    public string Audience { get; init; } = default!;
}
