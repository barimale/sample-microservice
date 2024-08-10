FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

COPY . ./
RUN dotnet build "./Ordering.API/Ordering.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "./Ordering.API/Ordering.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Ordering.API.dll"]
#CMD ASPNETCORE_URLS=http://*:$PORT dotnet Ordering.API.dll
