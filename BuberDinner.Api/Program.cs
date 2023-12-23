using BuberDinner.Api.Extensions;
using BuberDinner.Api.Middlewares;

var app = WebApplication.CreateBuilder().ConfigureServices().Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseExceptionHandler("/error");

app.UseHttpsRedirection();
app.MapControllers();

app.Run();