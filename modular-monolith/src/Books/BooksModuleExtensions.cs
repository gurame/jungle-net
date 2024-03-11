﻿using System.Reflection;
using Books.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Serilog;

namespace Books;

public static class BooksModuleExtensions
{
  public static IServiceCollection AddBooksModuleServices(this IServiceCollection services,
    ConfigurationManager config,
    ILogger logger, List<Assembly> mediatRAssemblies)
  {
    string? connectionString = config.GetConnectionString("BooksConnectionString");
    services.AddDbContext<BooksDbContext>(x =>
    {
      x.UseSqlServer(connectionString);
    });
    services.AddScoped<IBookRepository, EfBookRepository>();
    services.AddScoped<IBookService, BookService>();
    
    mediatRAssemblies.Add(typeof(BooksModuleExtensions).Assembly);
    
    logger.Information("{Module} module services registered", "Books");
    return services;
  }
}
