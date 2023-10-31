
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build-env
WORKDIR /App

COPY . ./

WORKDIR .
RUN dotnet restore ./minibank_client_api.csproj
RUN dotnet publish ./minibank_client_api.csproj -c Release -o out

FROM mcr.microsoft.com/dotnet/aspnet:6.0
WORKDIR /App
COPY --from=build-env /App/out .

ENTRYPOINT ["dotnet", "minibank_client_api.dll"]