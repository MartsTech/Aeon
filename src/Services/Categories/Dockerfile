FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
ENV ASPNETCORE_URLS=http://+:5002
WORKDIR /app
EXPOSE 5002

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["src/Services/Categories/src/Categories.csproj", "src/Services/Categories/src/"]
COPY ["src/BuildingBlocks/BuildingBlocks.csproj", "src/BuildingBlocks/"]
RUN dotnet restore "src/Services/Categories/src/Categories.csproj"
COPY . .
WORKDIR "/src/src/Services/Categories/src"
RUN dotnet build "Categories.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Categories.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Categories.dll"]
