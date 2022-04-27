#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["TradingPlatform.DatabaseService.WebApi/TradingPlatform.DatabaseService.WebApi.csproj", "TradingPlatform.DatabaseService.WebApi/"]
COPY ["TradingPlatform.DatabaseService.Presentation/TradingPlatform.DatabaseService.Presentation.csproj", "TradingPlatform.DatabaseService.Presentation/"]
COPY ["TradingPlatform.EntityContracts/TradingPlatform.EntityContracts.csproj", "TradingPlatform.EntityContracts/"]
COPY ["TradingPlatform.DatabaseService.Services.Abstractions/TradingPlatform.DatabaseService.Services.Abstractions.csproj", "TradingPlatform.DatabaseService.Services.Abstractions/"]
COPY ["TradingPlatform.DatabaseService.Services/TradingPlatform.DatabaseService.Services.csproj", "TradingPlatform.DatabaseService.Services/"]
COPY ["TradingPlatform.EntityExceptions/TradingPlatform.EntityExceptions.csproj", "TradingPlatform.EntityExceptions/"]
COPY ["TradingPlatform.DatabaseService.Domain/TradingPlatform.DatabaseService.Domain.csproj", "TradingPlatform.DatabaseService.Domain/"]
COPY ["TradingPlatform.DatabaseService.Persistence/TradingPlatform.DatabaseService.Persistence.csproj", "TradingPlatform.DatabaseService.Persistence/"]
RUN dotnet restore "TradingPlatform.DatabaseService.WebApi/TradingPlatform.DatabaseService.WebApi.csproj"
COPY . .
WORKDIR "/src/TradingPlatform.DatabaseService.WebApi"
RUN dotnet build "TradingPlatform.DatabaseService.WebApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "TradingPlatform.DatabaseService.WebApi.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "TradingPlatform.DatabaseService.WebApi.dll"]