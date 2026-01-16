# ---- Build stage ----
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# copy csproj and restore
COPY FaultCatalogAPI/FaultCatalogAPI.csproj FaultCatalogAPI/
RUN dotnet restore FaultCatalogAPI/FaultCatalogAPI.csproj

# copy everything and publish
COPY . .
RUN dotnet publish FaultCatalogAPI/FaultCatalogAPI.csproj -c Release -o /app/publish

# ---- Runtime stage ----
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY --from=build /app/publish .

EXPOSE 5000
ENV ASPNETCORE_URLS=http://+:5000
ENV ASPNETCORE_ENVIRONMENT=Development

ENTRYPOINT ["dotnet", "FaultCatalogAPI.dll"]
