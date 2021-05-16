FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build

COPY *.sln app/
COPY src/ app/src/

WORKDIR /app
RUN dotnet test --logger:trx

WORKDIR /app/src/Api
RUN dotnet publish -c Release -o /app/bin

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS runtime
COPY --from=build /app/bin ./

ENTRYPOINT ["dotnet", "api.dll"]




