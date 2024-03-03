install aspire
dotnet workload update
dotnet workload install aspire
dotnet new aspire --name WeahterApp.Aspire.AppHost
In case there is no Aspire Integration with IDE:
    - move projects manually
    - dotnet sln AspireShowcase.sln add WeahterApp.Aspire.AppHost WeahterApp.Aspire.ServiceDefaults




 