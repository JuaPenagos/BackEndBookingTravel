#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 8080

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["BackEndBookingTravel.Api/BackEndBookingTravel.Api.csproj", "BackEndBookingTravel.Api/"]
COPY ["BackEndBookingTravel.Application/BackEndBookingTravel.Application.csproj", "BackEndBookingTravel.Application/"]
COPY ["BackEndBookingTravel.Domain/BackEndBookingTravel.Domain.csproj", "BackEndBookingTravel.Domain/"]
COPY ["BackEndBookingTravel.Utility/BackEndBookingTravel.Utility.csproj", "BackEndBookingTravel.Utility/"]
COPY ["BackEndBookingTravel.Infrastructure.SQL/BackEndBookingTravel.Infrastructure.SQL.csproj", "BackEndBookingTravel.Infrastructure.SQL/"]
RUN dotnet restore "./BackEndBookingTravel.Api/BackEndBookingTravel.Api.csproj"
COPY . .
WORKDIR "/src/BackEndBookingTravel.Api"
RUN dotnet build "./BackEndBookingTravel.Api.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./BackEndBookingTravel.Api.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "BackEndBookingTravel.Api.dll"]