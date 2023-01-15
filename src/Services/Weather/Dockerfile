FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
ENV ASPNETCORE_URLS=http://+:5001
WORKDIR /app
EXPOSE 5001

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src

COPY ["src/Services/Weather/src/Weather.Api/Weather.Api.csproj", "src/Services/Weather/src/Weather.Api/"]
COPY ["src/Services/Weather/src/Weather.Application/Weather.Application.csproj", "src/Services/Weather/src/Weather.Application/"]
COPY ["src/Services/Weather/src//Weather.Persistence/Weather.Persistence.csproj", "src/Services/Weather/src/Weather.Persistence/"]
COPY ["src/Services/Weather/src/Weather.Domain/Weather.Domain.csproj", "src/Services/Weather/src/Weather.Domain/"]
COPY ["src/BuildingBlocks/BuildingBlocks.csproj", "src/BuildingBlocks/"]

RUN dotnet restore "src/Services/Weather/src/Weather.Api/Weather.Api.csproj"
COPY . .
WORKDIR "/src/src/Services/Weather/src/Weather.Api/"
RUN dotnet build "Weather.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Weather.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Weather.Api.dll"]
