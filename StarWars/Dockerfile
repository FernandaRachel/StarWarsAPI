#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["StarWars/StarWars.csproj", "StarWars/"]
RUN dotnet restore "StarWars/StarWars.csproj"
COPY . .
WORKDIR "/src/StarWars"
RUN dotnet build "StarWars.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "StarWars.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "StarWars.dll"]