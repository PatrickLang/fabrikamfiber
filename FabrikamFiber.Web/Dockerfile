FROM microsoft/aspnet:4.7.1-windowsservercore-1709
ARG source
WORKDIR /inetpub/wwwroot
# This next line is a workaround for an access denied issue. It should be removed eventually
RUN c:\windows\system32\inetsrv\appcmd.exe set AppPool DefaultAppPool '-processModel.identityType:LocalSystem'
COPY ${source:-obj/Docker/publish} .