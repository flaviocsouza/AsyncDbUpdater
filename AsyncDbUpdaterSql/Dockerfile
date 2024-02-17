FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app/AsyncDbUpdaterSql
EXPOSE 8080
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["AsyncDbUpdaterSql/AsyncDbUpdaterSql.csproj", "AsyncDbUpdaterSql/" ]
RUN dotnet restore "AsyncDbUpdaterSql/AsyncDbUpdaterSql.csproj"

WORKDIR "/src/AsyncDbUpdaterSql"
COPY AsyncDbUpdaterSql/. .
RUN dotnet build "AsyncDbUpdaterSql.csproj" -c Release -o /app/AsyncDbUpdaterSql/build

FROM build AS publish
RUN dotnet publish "AsyncDbUpdaterSql.csproj" -c Release -o /app/AsyncDbUpdaterSql/publish

FROM base AS final
WORKDIR /app/AsyncDbUpdaterSql
COPY --from=publish /app/AsyncDbUpdaterSql/publish .
ENTRYPOINT [ "dotnet", "AsyncDbUpdaterSql.dll" ]