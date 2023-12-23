using BuberDinner.Api.Common.Errors;
using BuberDinner.Api.Extensions;
using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace BuberDinner.Api;

public static class DependencyInjection
{
    public static IServiceCollection AddPresentationLayer(this IServiceCollection services)
    {
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();
        services.AddControllers();

        services.AddMappings();

        services.AddSingleton<ProblemDetailsFactory, AppProblemDetailsFactory>();

        return services;
    }
}