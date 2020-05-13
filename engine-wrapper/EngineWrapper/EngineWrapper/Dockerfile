#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/runtime:3.1-bionic AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-bionic AS build
WORKDIR /src
COPY ["EngineWrapper/EngineWrapper.csproj", "EngineWrapper/"]
COPY ["EngineWrapper.Interface/EngineWrapper.Interface.csproj", "EngineWrapper.Interface/"]
COPY ["EngineWrapper.DataLake/EngineWrapper.DataLake.csproj", "EngineWrapper.DataLake/"]
COPY ["EngineWrapper.Logger/EngineWrapper.Logger.csproj", "EngineWrapper.Logger/"]
COPY ["EngineWrapper.Utils/EngineWrapper.Utils.csproj", "EngineWrapper.Utils/"]
COPY ["EngineWrapper.MessageQueue/EngineWrapper.MessageQueue.csproj", "EngineWrapper.MessageQueue/"]
RUN dotnet restore "EngineWrapper/EngineWrapper.csproj"
COPY . .
WORKDIR "/src/EngineWrapper"
RUN dotnet build "EngineWrapper.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "EngineWrapper.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .

RUN apt-get update -y && apt-get install -y libboost-all-dev libssl-dev
COPY ./EngineWrapper /usr/lib
ENTRYPOINT ["dotnet", "EngineWrapper.dll"]