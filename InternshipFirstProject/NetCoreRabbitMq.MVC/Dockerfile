#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:3.1 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:3.1 AS build
WORKDIR /src
COPY ["InternshipFirstProject.MVC/InternshipFirstProject.MVC.csproj", "InternshipFirstProject.MVC/"]
COPY ["InternshipFirstProject.RabbitMQ/InternshipFirstProject.RabbitMQ.csproj", "InternshipFirstProject.RabbitMQ/"]
RUN dotnet restore "InternshipFirstProject.MVC/InternshipFirstProject.MVC.csproj"
COPY . .
WORKDIR "/src/InternshipFirstProject.MVC"
RUN dotnet build "InternshipFirstProject.MVC.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "InternshipFirstProject.MVC.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "InternshipFirstProject.MVC.dll"]