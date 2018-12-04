# FabrikamFiber

This project was originally started by Richard Hundhausen and distributed on [CodePlex](https://fabrikam.codeplex.com/) as an application for training users in Visual Studio and development practices.

I have archived it here since I frequently use it for examples rebuilding existing applications to run in containers.

### Building from the command line
  
What's needed:

- Windows 10 version 1803, Windows Server version 1803 or later
- Visual Studio 2017 (any edition)
- .Net Framework 4.7.2 SDK, ASP.Net Targeting Pack for Visual Studio
- Docker

Find "Developer Command Prompt for VS 2017" on the Start menu or by searching for it. Once the command window is open, change to the directory with the source code, and run these steps.
 

```cmd
rmdir /s /q MyCompany.Visitors.Web\bin\Release\Publish
msbuild FabrikamFiber.CallCenter.sln /t:clean /p:Configuration=Release
msbuild FabrikamFiber.CallCenter.sln /t:build /p:Configuration=Release /p:PublishProfile=FolderProfile /p:DeployOnBuild=true
cd FabrikamFiber.Web

docker build --no-cache -t ff .
docker run --rm -p 8080:80 -d ff
``` 
> Note: When you want to update the Windows and .Net container layers later, update then run `docker pull` on the base image given in the Dockerfile, then run `docker build` again.

 
## Kubernetes
 
This will create 2 deployments - one for web, one for the database, along with a shared secret. 
 
Description                         | Deployment Name              | Service
------------------------------------|------------------------------|-------------------------
Web site behind Azure load balancer | fabrikamfiber.web            | fabrikamfiberweb
SQL Server express database         | db                           | db
 
All 4 can be deployed using these steps:
 
```bash
kubectl apply -n ff -f k8s/db-mssql-linux.yaml
kubectl apply -n ff -f k8s/db-service.yaml
kubectl apply -n ff -f k8s/fabrikamfiber.web-deployment.yaml
kubectl apply -n ff -f k8s/fabrikamfiber.web-service.yaml
```

## Step by Step - Getting Started & Azure Service Fabric

There's a great guide on how to use this to test building Docker containers and deploying them to Azure Service Fabric [here](https://docs.microsoft.com/en-us/azure/service-fabric/service-fabric-host-app-in-a-container).

If you want to try a different orchestrator, follow the steps through the first **Test your container** section, then pick from the next sections here.