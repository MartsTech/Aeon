FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
ENV ASPNETCORE_URLS=http://+:5001
WORKDIR /app
EXPOSE 5001

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src

COPY ["src/Services/Bookmarks/src/Bookmarks.Api/Bookmarks.Api.csproj", "src/Services/Bookmarks/src/Bookmarks.Api/"]
COPY ["src/BuildingBlocks/BuildingBlocks.csproj", "src/BuildingBlocks/"]
COPY ["src/Services/Bookmarks/src/Bookmarks.Application/Bookmarks.Application.csproj", "src/Services/Bookmarks/src/Bookmarks.Application/"]
COPY ["src/Services/Bookmarks/src/Bookmarks.Domain/Bookmarks.Domain.csproj", "src/Services/Bookmarks/src/Bookmarks.Domain/"]
COPY ["src/Services/Bookmarks/src/Bookmarks.Persistence/Bookmarks.Persistence.csproj", "src/Services/Bookmarks/src/Bookmarks.Persistence/"]

RUN dotnet restore "src/Services/Bookmarks/src/Bookmarks.Api/Bookmarks.Api.csproj"
COPY . .
WORKDIR "/src/src/Services/Bookmarks/src/Bookmarks.Api"
RUN dotnet build "Bookmarks.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Bookmarks.Api.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Bookmarks.Api.dll"]