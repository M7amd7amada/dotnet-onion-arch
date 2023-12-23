using BuberDinner.Application;
using BuberDinner.Infrastructure;

namespace BuberDinner.Api.Extensions;

public static class Extensions
{
    public static WebApplicationBuilder ConfigureServices(this WebApplicationBuilder builder)
    {
        // * Adding The Layers Services * //
        builder.Services
            .AddApplicationLayer()
            .AddPresentationLayer()
            .AddInfrastructureLayer(builder.Configuration);

        return builder;
    }

}