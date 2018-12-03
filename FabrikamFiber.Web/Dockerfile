FROM mcr.microsoft.com/dotnet/framework/aspnet:4.7.2-windowsservercore-ltsc2019
ARG source
WORKDIR /inetpub/wwwroot
RUN c:\windows\system32\inetsrv\appcmd.exe set AppPool DefaultAppPool '-processModel.identityType:LocalSystem'
COPY ${source:-obj/Docker/publish} .
