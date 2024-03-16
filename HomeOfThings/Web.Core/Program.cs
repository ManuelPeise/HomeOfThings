using Microsoft.AspNetCore.Authentication.Cookies;
using Web.Core.Bundles;

var corsPolicy = "policy";
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

AppConfig.ConfigureCors(builder.Services, corsPolicy);
AppConfig.ConfigureDatabaseService(builder.Services, builder.Configuration);
AppConfig.ConfigureServices(builder.Services);
AppConfig.ConfigureRepositories(builder.Services);
AppConfig.ConfigureClients(builder.Services);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors(corsPolicy);

app.UseAuthorization();
app.UseAuthentication();

app.MapControllers();

DatabaseMaintanance.MigrateDatabase(builder.Services);
DatabaseMaintanance.SeedUserData(builder.Services, builder.Configuration);

app.Run();
