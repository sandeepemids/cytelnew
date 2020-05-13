FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["ProjectManager.Api/ProjectManager.Api.csproj", "./ProjectManager.Api/"]
RUN dotnet restore "ProjectManager.Api/ProjectManager.Api.csproj"
COPY . .
WORKDIR "/src/ProjectManager.Api"
RUN dotnet build "ProjectManager.Api.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "ProjectManager.Api.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "ProjectManager.Api.dll"]