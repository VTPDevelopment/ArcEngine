FROM mcr.microsoft.com/dotnet/runtime:6.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["OpenTKTests/OpenTKTests.csproj", "OpenTKTests/"]
RUN dotnet restore "OpenTKTests/OpenTKTests.csproj"
COPY . .
WORKDIR "/src/OpenTKTests"
RUN dotnet build "OpenTKTests.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "OpenTKTests.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "OpenTKTests.dll"]
