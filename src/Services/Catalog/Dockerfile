FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["src/Services/Catalog/src/Catalog.Api/Catalog.Api.csproj", "src/Services/Catalog/src/Catalog.Api/"]
COPY ["src/BuildingBlocks/BuildingBlocks.csproj", "src/BuildingBlocks/"]
COPY ["src/Services/Catalog/src/Catalog.Application/Catalog.Application.csproj", "src/Services/Catalog/src/Catalog.Application/"]
COPY ["src/Services/Catalog/src/Catalog.Domain/Catalog.Domain.csproj", "src/Services/Catalog/src/Catalog.Domain/"]
COPY ["src/Services/Catalog/src/Catalog.Persistence/Catalog.Persistence.csproj", "src/Services/Catalog/src/Catalog.Persistence/"]
RUN dotnet restore "src/Services/Catalog/src/Catalog.Api/Catalog.Api.csproj"
COPY . .
WORKDIR "/src/src/Services/Catalog/src/Catalog.Api"
RUN dotnet build "Catalog.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Catalog.Api.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Catalog.Api.dll"]