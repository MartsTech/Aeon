FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["src/Services/Products/src/Products.csproj", "src/Services/Products/src/"]
COPY ["src/BuildingBlocks/BuildingBlocks.csproj", "src/BuildingBlocks/"]
RUN dotnet restore "src/Services/Products/src/Products.csproj"
COPY . .
WORKDIR "/src/src/Services/Products/src"
RUN dotnet build "Products.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Products.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Products.dll"]