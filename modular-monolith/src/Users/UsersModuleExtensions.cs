using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Serilog;
using Users.Data;

namespace Users;

public static class BooksModuleExtensions
{
  public static IServiceCollection AddUsersModuleServices(
    this IServiceCollection services,
    ConfigurationManager config,
    ILogger logger)
  {
    string? connectionString = config.GetConnectionString("UsersConnectionString");
    services.AddDbContext<UsersDbContext>(x =>
    {
      x.UseSqlServer(connectionString);
    });

    services.AddIdentityCore<ApplicationUser>()
      .AddEntityFrameworkStores<UsersDbContext>();
    
    //services.AddScoped<IBookRepository, EfBookRepository>();
    
    logger.Information("{Module} module services registered", "Users");
    return services;
  }
}
