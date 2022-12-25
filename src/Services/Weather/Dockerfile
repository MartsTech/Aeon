FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["src/Services/Weather/Weather.csproj", "src/Services/Weather/"]
RUN dotnet restore "src/Services/Weather/Weather.csproj"
COPY . .
WORKDIR "/src/src/Services/Weather"
RUN dotnet build "Weather.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Weather.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Weather.dll"]
