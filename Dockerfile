# desenvolvimento heroku
FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build

# copiar csproj e restaurar como camadas distintas
COPY *.sln App/
COPY Domain/*.csproj App/Domain/
COPY Infra/*.csproj App/Infra/
COPY Tests/*.csproj App/Tests/
COPY Api/*.csproj App/Api/

WORKDIR /App
RUN dotnet restore

# copie todo o resto e crie um aplicativo
COPY Api/. ./Api/
COPY Domain/. ./Domain/
COPY Infra/. ./Infra/
COPY Tests/. ./Tests/

WORKDIR /App/Api
RUN dotnet publish -c Release -o out

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1 AS runtime
WORKDIR /App
COPY --from=build /App/Api/out ./

CMD ASPNETCORE_URLS=http://*:$PORT dotnet api.dll



