FROM mcr.microsoft.com/dotnet/aspnet:10.0 AS base
WORKDIR /app
EXPOSE 8080
ENV ASPNETCORE_URLS=http://+:8080

FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
WORKDIR /src
COPY ["src/SecureMailGateway/SecureMailGateway.csproj", "SecureMailGateway/"]
RUN dotnet restore "SecureMailGateway/SecureMailGateway.csproj"
COPY src/SecureMailGateway/ SecureMailGateway/
WORKDIR /src/SecureMailGateway
RUN dotnet publish -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=build /app/publish .
RUN mkdir -p /app/logs /app/keys
ENTRYPOINT ["dotnet", "SecureMailGateway.dll"]
