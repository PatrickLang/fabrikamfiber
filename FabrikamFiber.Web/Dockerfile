FROM mcr.microsoft.com/dotnet/framework/aspnet:4.7.2-windowsservercore-ltsc2019
ARG source
WORKDIR /inetpub/wwwroot
RUN c:\windows\system32\inetsrv\appcmd.exe set AppPool DefaultAppPool '-processModel.identityType:LocalSystem'
COPY bin/release/publish .
ADD https://github.com/microsoft/windows-container-tools/releases/download/v1.0/LogMonitor.exe c:/LogMonitor/LogMonitor.exe
ADD LogMonitorConfig.json c:/LogMonitor/
SHELL ["C:\\LogMonitor\\LogMonitor.exe", "powershell.exe"]
 
# Start IIS Remote Management and monitor IIS
ENTRYPOINT      Start-Service W3SVC; C:\\ServiceMonitor.exe w3svc