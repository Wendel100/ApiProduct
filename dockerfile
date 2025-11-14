# Build stage
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copia csproj e restaura dependências (cache)
COPY EcoApi.csproj ./
RUN dotnet restore EcoApi.csproj

# Copia todo o código e publica
COPY . .
RUN dotnet publish EcoApi.csproj -c Release -o /app/publish /p:UseAppHost=false

# Runtime stage
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app

# Variável para o Kestrel escutar na porta 8080
ENV ASPNETCORE_URLS=http://+:8080

COPY --from=build /app/publish .

EXPOSE 8080

ENTRYPOINT ["dotnet", "EcoApi.dll"]
