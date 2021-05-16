ARG  DOTNET_VERSION=5.0
FROM mcr.microsoft.com/dotnet/sdk:${DOTNET_VERSION} AS build

COPY seed-sqlite /seeds/
RUN dotnet publish -c Release -o /seeds/bin/

COPY *.sln /app/
COPY src/ /app/src

WORKDIR /app
RUN dotnet test --logger:trx

WORKDIR /app/src/Api
RUN dotnet publish -c Release -o /app/bin

FROM mcr.microsoft.com/dotnet/aspnet:${DOTNET_VERSION} AS runtime
COPY --from=build /app/bin .

EXPOSE 6050

ENTRYPOINT ["dotnet", "api.dll"]




