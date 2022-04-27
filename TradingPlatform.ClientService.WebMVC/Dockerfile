#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["TradingPlatform.ClientService.WebMVC/TradingPlatform.ClientService.WebMVC.csproj", "TradingPlatform.ClientService.WebMVC/"]
COPY ["TradingPlatform.ClientService.Services/TradingPlatform.ClientService.Services.csproj", "TradingPlatform.ClientService.Services/"]
COPY ["TradingPlatform.EntityContracts/TradingPlatform.EntityContracts.csproj", "TradingPlatform.EntityContracts/"]
COPY ["TradingPlatform.ClientService.Contracts/TradingPlatform.ClientService.Contracts.csproj", "TradingPlatform.ClientService.Contracts/"]
COPY ["TradingPlatform.ClientService.Persistence/TradingPlatform.ClientService.Persistence.csproj", "TradingPlatform.ClientService.Persistence/"]
COPY ["TradingPlatform.EntityExceptions/TradingPlatform.EntityExceptions.csproj", "TradingPlatform.EntityExceptions/"]
COPY ["TradingPlatform.ClientService.Domain/TradingPlatform.ClientService.Domain.csproj", "TradingPlatform.ClientService.Domain/"]
COPY ["TradingPlatform.ClientService.Services.Abstractions/TradingPlatform.ClientService.Services.Abstractions.csproj", "TradingPlatform.ClientService.Services.Abstractions/"]
COPY ["TradingPlatform.ClientService.Presentation/TradingPlatform.ClientService.Presentation.csproj", "TradingPlatform.ClientService.Presentation/"]
RUN dotnet restore "TradingPlatform.ClientService.WebMVC/TradingPlatform.ClientService.WebMVC.csproj"
COPY . .
WORKDIR "/src/TradingPlatform.ClientService.WebMVC"
RUN dotnet build "TradingPlatform.ClientService.WebMVC.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "TradingPlatform.ClientService.WebMVC.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "TradingPlatform.ClientService.WebMVC.dll"]