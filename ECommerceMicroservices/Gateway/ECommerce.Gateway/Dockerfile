FROM mcr.microsoft.com/dotnet/sdk:5.0-buster-slim as build
WORKDIR /app
EXPOSE 80

COPY Gateway/ECommerce.Gateway/*.csproj  Gateway/ECommerce.Gateway/
RUN dotnet restore Gateway/ECommerce.Gateway/*.csproj
COPY . .
RUN dotnet publish Gateway/ECommerce.Gateway/*.csproj -c Release -o out
FROM mcr.microsoft.com/dotnet/aspnet:5.0-buster-slim as runtime
WORKDIR /app
COPY --from=build /app/out .
ENTRYPOINT [ "dotnet","ECommerce.Gateway.dll" ]
