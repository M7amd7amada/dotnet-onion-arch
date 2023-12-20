namespace BuberDinner.Application.Common.Interfaces.Services;

public interface IDateTimeProvider
{
    public DateTime Now { get; }
    public DateTime UtcNow { get; }
}