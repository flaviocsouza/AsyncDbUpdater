FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["AsyncDbUpdaterApi/AsyncDbUpdaterApi.csproj", "AsyncDbUpdaterApi/" ]
RUN dotnet restore "AsyncDbUpdaterApi/AsyncDbUpdaterApi.csproj"

WORKDIR "/src/AsyncDbUpdaterApi"
COPY AsyncDbUpdaterApi/. .
RUN dotnet build "AsyncDbUpdaterApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "AsyncDbUpdaterApi.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT [ "dotnet", "AsyncDbUpdaterApi.dll" ]