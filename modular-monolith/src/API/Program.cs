using Books;
using Users;
using FastEndpoints;
using FastEndpoints.Security;
using FastEndpoints.Swagger;
using Serilog;

var logger = Log.Logger = new LoggerConfiguration()
  .Enrich.FromLogContext()
  .WriteTo.Console()
  .CreateLogger();

logger.Information("Starting API Host");

var builder = WebApplication.CreateBuilder(args);

builder.Host.UseSerilog((_, config) =>
{
  config.ReadFrom.Configuration(builder.Configuration);
});

builder.Services.AddFastEndpoints()
  .AddAuthenticationJwtBearer(x =>
  {
    x.SigningKey = builder.Configuration["Auth:JwtSecret"];
  })
  .AddAuthorization()
  .SwaggerDocument();

// Add module services
builder.Services.AddBooksModuleServices(builder.Configuration, logger);
builder.Services.AddUsersModuleServices(builder.Configuration, logger);

var app = builder.Build();

app.UseAuthentication()
  .UseAuthorization();

app.UseFastEndpoints()
  .UseSwaggerGen();

app.Run();
public partial class Program {}
