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
## Docker build
```
docker build -t foo . && docker run -it -p 1433:1433 -p 15672:15672 -p 5672:5672 foo
```
## Docker externalls [docker compose later]
```
docker run -it --rm --name eventstore-node -p 2113:2113 -p 1113:1113 eventstore/eventstore:release-5.0.11
docker run -it --rm -e "ACCEPT_EULA=Y" -e "MSSQL_SA_PASSWORD=<YourStrong@Passw0rd>" -p 1433:1433 --name sql1 --hostname sql1 -d mcr.microsoft.com/mssql/server:2022-latest
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

https://medium.com/@no1.melman10/getting-started-with-eventstoredb-c-13411ec08713

https://medium.com/@abhinandkr56/crud-operations-using-eventstoredb-in-net-b851f65bd028

https://eventuous.dev/docs/persistence/event-store

https://github.com/Eventuous/eventuous/tree/dev/samples

https://www.milanjovanovic.tech/blog/implementing-the-saga-pattern-with-rebus-and-rabbitmq

https://github.com/mookid8000/Cirqus

https://github.com/m-jovanovic/newsletter-orchestrated-saga 

https://github.com/rebus-org/RebusSamples/blob/master/Sagas/SagaDemo/Handlers/PayoutSaga.cs

https://github.com/b-y-t-e/TheSaga

https://medium.com/@jeslurrahman/implementing-health-checks-in-net-8-c3ba10af83c3#:~:text=To%20check%20the%20health%20of%20your%20web%20API%2C,that%20your%20web%20API%20is%20marked%20as%20%E2%80%9CHealthy.%E2%80%9D

https://medium.com/aspnetrun/securing-microservices-with-identityserver4-with-oauth2-and-openid-connect-fronted-by-ocelot-api-49ea44a0cf9e

https://medium.com/@omar.nebi147/integrating-keycloak-with-net-core-web-api-6-986fa0a81063
