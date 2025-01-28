# Bruk en offisiell .NET SDK for bygging
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app

# Kopier prosjektene og gjenopprett avhengigheter
COPY . ./
RUN dotnet restore

# Bygg applikasjonen
RUN dotnet publish -c Release -o /publish

# Bruk en lettere runtime-image
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app
COPY --from=build /publish ./

# Start applikasjonen
CMD ["dotnet", "MyApi.dll"]
