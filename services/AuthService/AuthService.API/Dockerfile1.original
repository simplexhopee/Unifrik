#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["services/AuthService/AuthService.API/AuthService.API.csproj", "services/AuthService/AuthService.API/"]
COPY ["shared/Unifrik.Infrastructure.Shared/Unifrik.Infrastructure.Shared.csproj", "shared/Unifrik.Infrastructure.Shared/"]
COPY ["shared/Unifrik.Domain.Shared/Unifrik.Domain.Shared.csproj", "shared/Unifrik.Domain.Shared/"]
COPY ["services/AuthService/AuthService.Application/AuthService.Application.csproj", "services/AuthService/AuthService.Application/"]
COPY ["services/AuthService/AuthService.Contracts/AuthService.Contracts.csproj", "services/AuthService/AuthService.Contracts/"]
COPY ["services/AuthService/AuthService.Domain/AuthService.Domain.csproj", "services/AuthService/AuthService.Domain/"]
COPY ["services/AuthService/AuthService.Infrastructure/AuthService.Infrastructure.csproj", "services/AuthService/AuthService.Infrastructure/"]
RUN dotnet restore "./services/AuthService/AuthService.API/./AuthService.API.csproj"
COPY . .
WORKDIR "/src/services/AuthService/AuthService.API"
RUN dotnet build "./AuthService.API.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./AuthService.API.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "AuthService.API.dll"]