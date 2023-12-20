using BuberDinner.Application;

namespace BuberDinner.Api.Extensions;

public static class Extensions
{
    public static WebApplicationBuilder ConfigureServices(this WebApplicationBuilder builder)
    {
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();
        builder.Services.AddControllers();

        // * Adding The Layers * //
        builder.Services.AddApplicationLayer();

        return builder;
    }

}