# escape=`
FROM mcr.microsoft.com/dotnet/framework/sdk:4.7.2-20190312-windowsservercore-ltsc2019 AS builder

WORKDIR C:\src
COPY FabrikamFiber.CallCenter.sln .
COPY FabrikamFiber.DAL\FabrikamFiber.DAL.csproj .\FabrikamFiber.DAL\
COPY FabrikamFiber.DAL\packages.config .\FabrikamFiber.DAL\
COPY FabrikamFiber.Web\FabrikamFiber.Web.csproj .\FabrikamFiber.Web\
COPY FabrikamFiber.Web\packages.config .\FabrikamFiber.Web\
RUN nuget restore FabrikamFiber.CallCenter.sln

COPY FabrikamFiber.DAL\ .\FabrikamFiber.DAL\
COPY FabrikamFiber.Web\ .\FabrikamFiber.Web\
RUN msbuild FabrikamFiber.Web\FabrikamFiber.Web.csproj /p:OutputPath=c:\out /p:Configuration=Release

# app image
FROM mcr.microsoft.com/dotnet/framework/aspnet:4.7.2-windowsservercore-ltsc2019
SHELL ["powershell", "-Command", "$ErrorActionPreference = 'Stop';"]

ENV APP_ROOT=C:\inetpub\wwwroot `
    DB_SERVICE_HOST=ff-db `
    DB_SERVICE_PORT=1433 `
    DB_SA_PASSWORD=DockerCon!!!

WORKDIR ${APP_ROOT}
RUN Import-Module WebAdministration; `
    Set-ItemProperty 'IIS:\AppPools\DefaultAppPool' -Name processModel.identityType -Value LocalSystem

COPY --from=builder C:\out\_PublishedWebsites\FabrikamFiber.Web ${APP_ROOT}