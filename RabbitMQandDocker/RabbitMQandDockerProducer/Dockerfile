#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:3.1 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:3.1 AS build
WORKDIR /src
COPY ["RabbitMQandDockerProducer/RabbitMQandDockerProducer.csproj", "RabbitMQandDockerProducer/"]
RUN dotnet restore "RabbitMQandDockerProducer/RabbitMQandDockerProducer.csproj"
COPY . .
WORKDIR "/src/RabbitMQandDockerProducer"
RUN dotnet build "RabbitMQandDockerProducer.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "RabbitMQandDockerProducer.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "RabbitMQandDockerProducer.dll"]