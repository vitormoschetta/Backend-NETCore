# producao local
FROM mcr.microsoft.com/dotnet/core/aspnet:3.1
COPY Api/bin/Release/netcoreapp3.1/publish/ App/src/
COPY Domain/bin/Release/netstandard2.0/ App/src
COPY Infra/bin/Release/netstandard2.0/ App/src
WORKDIR /App/src/
ENTRYPOINT ["dotnet", "Api.dll"]
