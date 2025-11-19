# Build stage
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

COPY EcoApi.csproj ./
RUN dotnet restore

<<<<<<< HEAD
COPY . ./
=======
COPY . .
>>>>>>> 1100f97129eaf38349c27b7aafb33fdbb715a3a9
RUN dotnet publish -c Release -o /app/publish /p:UseAppHost=false

# Runtime stage
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app

<<<<<<< HEAD
# Render usa a variável PORT - fallback para 8080 se rodar local
ENV ASPNETCORE_URLS=http://0.0.0.0:${PORT:-8080}
=======
# Render define PORT automaticamente
ENV ASPNETCORE_URLS=http://0.0.0.0:${PORT}
>>>>>>> 1100f97129eaf38349c27b7aafb33fdbb715a3a9

COPY --from=build /app/publish .

# Apenas informativo

EXPOSE 8080

ENTRYPOINT ["dotnet", "EcoApi.dll"]
