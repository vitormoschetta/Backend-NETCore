FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build

COPY *.sln App/
COPY src/Domain/*.csproj App/src/Domain/
COPY src/Infra/*.csproj App/src/Infra/
COPY src/Tests/*.csproj App/src/Tests/
COPY src/Api/*.csproj App/src/Api/

WORKDIR /App
RUN dotnet restore

COPY src/Api/. ./Api/
COPY src/Domain/. ./Domain/
COPY src/Infra/. ./Infra/
COPY src/Tests/. ./Tests/

WORKDIR /App
RUN dotnet test --logger:trx

WORKDIR /App/Api
RUN dotnet publish -c Release -o out

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1 AS runtime
COPY --from=build /App/Api/out ./

ENTRYPOINT ["dotnet", "api.dll"]




