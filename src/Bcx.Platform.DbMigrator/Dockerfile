#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/runtime:5.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
# COPY ["nuget.config", "."]
COPY ["src/Bcx.Platform.DbMigrator/Bcx.Platform.DbMigrator.csproj", "src/Bcx.Platform.DbMigrator/"]
COPY ["src/Bcx.Platform.EntityFrameworkCore.DbMigrations/Bcx.Platform.EntityFrameworkCore.DbMigrations.csproj", "src/Bcx.Platform.EntityFrameworkCore.DbMigrations/"]
COPY ["src/Bcx.Platform.EntityFrameworkCore/Bcx.Platform.EntityFrameworkCore.csproj", "src/Bcx.Platform.EntityFrameworkCore/"]
COPY ["src/Bcx.Platform.Domain/Bcx.Platform.Domain.csproj", "src/Bcx.Platform.Domain/"]
COPY ["src/Bcx.Platform.Domain.Shared/Bcx.Platform.Domain.Shared.csproj", "src/Bcx.Platform.Domain.Shared/"]
COPY ["src/Bcx.Platform.Application.Contracts/Bcx.Platform.Application.Contracts.csproj", "src/Bcx.Platform.Application.Contracts/"]
RUN dotnet restore "src/Bcx.Platform.DbMigrator/Bcx.Platform.DbMigrator.csproj"
COPY . .
WORKDIR "/src/src/Bcx.Platform.DbMigrator"
RUN dotnet build "Bcx.Platform.DbMigrator.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Bcx.Platform.DbMigrator.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Bcx.Platform.DbMigrator.dll"]