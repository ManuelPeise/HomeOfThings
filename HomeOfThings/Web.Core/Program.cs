using Microsoft.AspNetCore.Authentication.Cookies;
using Web.Core.Bundles;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

AppConfig.ConfigureDatabaseService(builder.Services, builder.Configuration);
AppConfig.ConfigureServices(builder.Services);
AppConfig.ConfigureRepositories(builder.Services);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();
app.UseAuthentication();

app.MapControllers();

app.Run();