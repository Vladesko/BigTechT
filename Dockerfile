FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 5000


WORKDIR /src
COPY ["/WebApi/WebApi.csproj", "/src/WebApi/"]
COPY ["/Application/Application.csproj", "/src/Application/"]
COPY ["/Domain/Domain.csproj", "/src/Domain/"]
COPY ["/Persistence/Persistence.csproj", "/src/Persistence/"]
COPY ["/HttpModels/HttpModels.csproj", "/src/HttpModels/"]
COPY ["/Logging/Logging.csproj", "/src/Logging/"]
COPY ["/TelemetryAndTracing/TelemetryAndTracing.csproj", "/src/TelemetryAndTracing/"]

COPY . .

RUN dotnet restore "/src/WebApi/WebApi.csproj"

WORKDIR "/src/WebApi"

RUN dotnet build "WebApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "WebApi.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "WebApi.dll"]