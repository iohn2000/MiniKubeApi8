# Use the official .NET SDK image for building the application
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app

# Copy the project files and restore dependencies
COPY *.csproj .
RUN dotnet restore

# Copy the remaining files and build the project
COPY . .
RUN dotnet publish -c Release

# Use the official runtime image to run the application
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app
COPY --from=build /app/bin/Release/net8.0/publish .


# Set the environment variable to specify the listening port
ENV ASPNETCORE_URLS=http://+:8080

# Expose the port
EXPOSE 8080

ENTRYPOINT ["dotnet", "MiniKubeApi8.dll"]