# Used for docker-compose and running of app

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["./Toshi.Core.Api/Toshi.Core.Api.csproj", "Toshi.Core.Api/"]
COPY ["./Toshi.Core.Shared/Toshi.Core.Shared.csproj", "Toshi.Core.Shared/"]

RUN dotnet restore "./Toshi.Core.Api/Toshi.Core.Api.csproj"

COPY . .
WORKDIR "/src/Toshi.Core.Api"
RUN dotnet build "./Toshi.Core.Api.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./Toshi.Core.Api.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Toshi.Core.Api.dll"]