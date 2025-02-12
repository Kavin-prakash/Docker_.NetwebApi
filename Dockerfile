# Base runtime image with required libraries
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 9550

# Install missing Kerberos library for SQL Server
# RUN apt-get update && apt-get install -y libgssapi-krb5-2 && rm -rf /var/lib/apt/lists/*

# Build image
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["AzureWebApi.csproj", "./"]
RUN dotnet restore "AzureWebApi.csproj"
COPY . .
RUN dotnet build "AzureWebApi.csproj" -c $BUILD_CONFIGURATION -o /app/build

# Publish image
FROM build AS publish
RUN dotnet publish "AzureWebApi.csproj" -c $BUILD_CONFIGURATION -o /app/publish

# Final runtime image
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .

# Set the environment variable to listen on all interfaces (important for Docker)
ENV ASPNETCORE_URLS="http://+:9550"

ENTRYPOINT ["dotnet", "AzureWebApi.dll"]