var builder = DistributedApplication.CreateBuilder(args);

var api = builder.AddProject<Projects.WeatherApp_Api>("api");
builder.AddProject<Projects.WeatherApp_Web>("web")
    .WithReference(api);

builder.Build().Run();
