# Microservices challenges
- Network latency
- Message serialization
- Inter-service communication
- Data consistency

### Incremental design approach 
Monolith is gradually broken into microservices. <br/> 
A common pitfall is ending up what is often termed as a distributed monolith.
This happens when services are so tightly coupled in terms of functionality and
communication that they lose the benefits of being independent

### Comparison
| Trade-offs  | Layered | Microservices | Modular Monolith |
|:------------|:-------:|:-------------:|:----------------:|
| Modularity  |    ❌    |      ✔️️      |       ✔️️        |
| Cost        |    $    |      $$$      |        $         |
| Scalability |    ❌    |      ✔️️      |        ❌         |
| Simplicity  |   ✔️    |       ❌       |       ✔️️        |

## Create project
create the solution
```zsh
dotnet new sln -n RiverBooks
```
create src directory
```zsh
mkdir src
``` 
create web api project
```zsh
dotnet new webapi -n API -o src
```
add web api project to solution
```zsh
dotnet sln RiverBooks.sln add ./src/API/API.csproj
```
create library project
```zsh
dotnet new classlib -n Books -o src/Books
```
add library project to solution
```zsh
dotnet sln RiverBooks.sln add ./src/Books/Books.csproj
```
add library project as reference to web api project
```zsh
dotnet add src/API/API.csproj reference src/Books/Books.csproj
```
add framework reference to library project
```
<ItemGroup>
<FrameworkReference Include="Microsoft.AspNetCore.App" />
</ItemGroup>
```
add FastEndpoints to projects
```zsh
dotnet add src/API/API.csproj package FastEndpoints
dotnet add src/Books/Books.csproj package FastEndpoints
``` 