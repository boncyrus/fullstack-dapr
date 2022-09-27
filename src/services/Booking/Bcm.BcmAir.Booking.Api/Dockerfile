#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY . .
RUN dotnet restore "./services/Booking/Bcm.BcmAir.Booking.Api/Bcm.BcmAir.Booking.Api.csproj"
WORKDIR "/src/services/Catalog/Bcm.BcmAir.Booking.Api"
RUN dotnet build "Bcm.BcmAir.Catalog.Booking.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Bcm.BcmAir.Booking.Api.csproj" -c Release -o /app/publish --no-restore

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Bcm.BcmAir.Booking.Api.dll"]