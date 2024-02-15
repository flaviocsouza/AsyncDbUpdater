FROM mcr.microsoft.com/dotnet/runtime:8.0 AS base
WORKDIR /app/AsyncDbUpdaterSql

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["AsyncDbUpdaterSql/AsyncDbUpdaterSql.csproj", "AsyncDbUpdaterSql/" ]
RUN dotnet restore "AsyncDbUpdaterSql/AsyncDbUpdaterSql.csproj"

FROM build AS publish
WORKDIR "/src/AsyncDbUpdaterSql"
COPY AsyncDbUpdaterSql/. .
RUN dotnet publish "AsyncDbUpdaterSql.csproj" -c Release -o /app/AsyncDbUpdaterSql/publish

FROM base AS final
WORKDIR /app/AsyncDbUpdaterSql
COPY --from=publish /app/AsyncDbUpdaterSql/publish .
ENTRYPOINT [ "dotnet", "AsyncDbUpdaterSql.dll" ]