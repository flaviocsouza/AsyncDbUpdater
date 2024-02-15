FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app/AsyncDbUpdaterApi
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["AsyncDbUpdaterApi/AsyncDbUpdaterApi.csproj", "AsyncDbUpdaterApi/" ]
RUN dotnet restore "AsyncDbUpdaterApi/AsyncDbUpdaterApi.csproj"

WORKDIR "/src/AsyncDbUpdaterApi"
COPY AsyncDbUpdaterApi/. .
RUN dotnet build "AsyncDbUpdaterApi.csproj" -c Release -o /app/AsyncDbUpdaterApi/build

FROM build AS publish
RUN dotnet publish "AsyncDbUpdaterApi.csproj" -c Release -o /app/AsyncDbUpdaterApi/publish

FROM base AS final
WORKDIR /app/AsyncDbUpdaterApi
COPY --from=publish /app/AsyncDbUpdaterApi/publish .
ENTRYPOINT [ "dotnet", "AsyncDbUpdaterApi.dll" ]