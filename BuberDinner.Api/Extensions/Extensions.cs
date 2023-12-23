using BuberDinner.Api.Common.Errors;
using BuberDinner.Application;
using BuberDinner.Infrastructure;
using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace BuberDinner.Api.Extensions;

public static class Extensions
{
    public static WebApplicationBuilder ConfigureServices(this WebApplicationBuilder builder)
    {
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        builder.Services.AddControllers();

        builder.Services.AddSingleton<ProblemDetailsFactory, AppProblemDetailsFactory>();

        // * Adding The Layers * //
        builder.Services
            .AddApplicationLayer()
            .AddInfrastructureLayer(builder.Configuration);


        return builder;
    }

}