# Description
## Concept
Design as a monorepo
## It is a POC
Some things are not implemented yet, project contains just sample solutions. Some parts of code not ready(for example sagas).
## Database:
navigate to the database project directory first.
Then execute as follows:
```
dotnet tool install --global dotnet-ef
dotnet add package Microsoft.EntityFrameworkCore.Design
dotnet ef migrations add InitialCreate
dotnet ef database update

dotnet ef database update --connection "Data Source=MATEUSZ;Initial Catalog=DataBaseName;TrustServerCertificate=True;Integrated Security=True;"```
```
# sample-microservice - links

https://medium.com/@avinash.dhumal/exploring-microservices-saga-and-compensation-patterns-with-c-example-0da3dfe87bb6

https://learn.microsoft.com/en-us/dotnet/architecture/microservices/multi-container-microservice-net-applications/rabbitmq-event-bus-development-test-environment

https://learn.microsoft.com/en-us/aspnet/core/fundamentals/http-requests?view=aspnetcore-8.0

https://github.com/dotnet/AspNetCore.Docs/blob/main/aspnetcore/fundamentals/http-requests/samples/6.x/HttpRequestsSample/GitHub/GitHubService.cs

https://github.com/aspnetrun/run-aspnetcore-microservices/tree/master

https://medium.com/@seldah/managing-multiple-versions-of-your-api-with-net-and-swagger-47b4143e8bf5

https://www.roundthecode.com/dotnet-tutorials/create-custom-database-logging-provider-asp-net-core-ilogger

https://code-maze.com/cqrs-mediatr-fluentvalidation/

https://dev.to/kaz_254/fluent-validation-in-aspnet-web-api-5d0o

https://timdeschryver.dev/blog/refactor-your-net-http-clients-to-typed-http-clients#refactor-to-named-http-clients

https://stackoverflow.com/questions/34834295/dependency-injection-inject-with-parameters

https://learn.microsoft.com/en-us/aspnet/core/fundamentals/minimal-apis/min-api-filters?view=aspnetcore-8.0

https://github.com/oskardudycz/EventSourcing.NetCore

https://learn.microsoft.com/en-us/aspnet/core/fundamentals/http-logging/?view=aspnetcore-8.0

https://github.com/geeksarray/how-to-use-automapper-in-aspnet-core-web-api/blob/main/GeekStore.API.Core/Configurations/MapperConfig.cs
