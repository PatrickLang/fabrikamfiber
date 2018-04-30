FROM patricklang/fabrikamfiber.web:1709
ADD Web.config c:\\inetpub\\wwwroot
ADD start.ps1 /
ENTRYPOINT ["powershell.exe", "c:\\start.ps1"]