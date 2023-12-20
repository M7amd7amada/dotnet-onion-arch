using BuberDinner.Application;
using BuberDinner.Infrastructure;

namespace BuberDinner.Api.Extensions;

public static class Extensions
{
    public static WebApplicationBuilder ConfigureServices(this WebApplicationBuilder builder)
    {
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();
        builder.Services.AddControllers();

        // * Adding The Layers * //
        builder.Services
            .AddApplicationLayer()
            .AddInfrastructureLayer();


        return builder;
    }

}