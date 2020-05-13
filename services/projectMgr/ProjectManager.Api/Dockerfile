#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["ProjectManager.Api/ProjectManager.Api.csproj", "ProjectManager.Api/"]
COPY ["ProjectManager.Service/ProjectManager.Service.csproj", "ProjectManager.Service/"]
COPY ["ProjectManager.Models/ProjectManager.Models.csproj", "ProjectManager.Models/"]
COPY ["ProjectManager.Constants/ProjectManager.Constants.csproj", "ProjectManager.Constants/"]
COPY ["ProjectManager.DataAccess/ProjectManager.DataAccess.csproj", "ProjectManager.DataAccess/"]
RUN dotnet restore "ProjectManager.Api/ProjectManager.Api.csproj"
COPY . .
WORKDIR "/src/ProjectManager.Api"
RUN dotnet build "ProjectManager.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ProjectManager.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ProjectManager.Api.dll"]