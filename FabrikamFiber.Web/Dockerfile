FROM microsoft/aspnet:4.7.1-windowsservercore-1709 
ARG source
WORKDIR /inetpub/wwwroot
RUN c:\windows\system32\inetsrv\appcmd.exe set AppPool DefaultAppPool '-processModel.identityType:LocalSystem'
COPY ${source:-obj/Docker/publish} .
