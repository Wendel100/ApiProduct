# Build stage
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

COPY EcoApi.csproj ./
RUN dotnet restore

COPY . ./
RUN dotnet publish -c Release -o /app/publish /p:UseAppHost=false

# Runtime stage
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app

# Render usa a variável PORT - fallback para 8080 se rodar local
ENV ASPNETCORE_URLS=http://0.0.0.0:${PORT:-8080}

COPY --from=build /app/publish .

# Apenas informativo
EXPOSE 8080

ENTRYPOINT ["dotnet", "EcoApi.dll"]
