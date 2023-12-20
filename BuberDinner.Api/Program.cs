using BuberDinner.Api.Extensions;

var app = WebApplication.CreateBuilder().ConfigureServices().Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.MapControllers();

app.Run();