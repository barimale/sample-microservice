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
## Docker
```
docker build -t foo . && docker run -it foo
```
## RabbitMQ
```
docker run -it --rm --name rabbitmq -p 5672:5672 -p 15672:15672 rabbitmq:3.13-management
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

https://github.com/madslundt/NetCoreMicroservicesSample

https://github.com/ruhollahjafari1994/.NET-Microservices-CQRS-Event-Sourcing-with-Kafka/tree/main

https://blog.stackademic.com/implementation-of-saga-orchestration-using-masstransit-dd238530f0d7

https://medium.com/multinetinventiv/publish-and-consume-messages-with-masstransit-and-rabbitmq-on-net-6-6118377bfedb

https://learn.microsoft.com/en-us/dotnet/architecture/microservices/multi-container-microservice-net-applications/background-tasks-with-ihostedservice

https://andrewhalil.com/2022/01/03/using-the-ioptions-pattern-in-a-net-core-application/#:~:text=The%20ability%20to%20inject%20settings%20keys%20and%20their,format%20of%20this%20file%20is%20shown%20as%20follows%3A

https://medium.com/c-sharp-progarmming/handling-errors-with-iexceptionhandler-in-net-8-12c13e651639#:~:text=The%20IExceptionHandler%20is%20an%20interface%20that%20allows%20developers,and%20take%20specific%20actions%20to%20deal%20with%20them.

https://developers.eventstore.com/clients/tcp/dotnet/21.2/#appending-events

https://github.com/aspnetrun/run-aspnetcore-microservices
