# FabrikamFiber

This project was originally started by Richard Hundhausen and distributed on [CodePlex](https://fabrikam.codeplex.com/) as an application for training users in Visual Studio and development practices.

I have archived it here since I frequently use it for examples rebuilding existing applications to run in containers.

## Building this project
  
What's needed:

- Windows 10 version 1803, Windows Server version 1803 or later
- Visual Studio 2017 or later (any edition)
    - During install - also select the .Net Framework 4.7.2 SDK, and ASP.Net Targeting Pack for Visual Studio
- [nuget.exe](https://dist.nuget.org/win-x86-commandline/latest/nuget.exe)
- Docker

### Steps to build

1. Find "Developer Command Prompt for VS 2017" (or VS 2019) on the Start menu or by searching for it. Once the command window is open, change to the directory with the source code, and run these steps.

```cmd
nuget.exe restore
msbuild FabrikamFiber.CallCenter.sln /t:clean /p:Configuration=Release
msbuild FabrikamFiber.CallCenter.sln /t:build /p:Configuration=Release /p:PublishProfile=FolderProfile /p:DeployOnBuild=true
cd FabrikamFiber.Web

docker build --no-cache -t ff .
docker run --rm -p 8080:80 -d ff
``` 

> Note: When you want to update the Windows and .Net container layers later, update then run `docker pull` on the base image given in the Dockerfile, then run `docker build` again.

You can make sure the container started the app by browsing to http://localhost:8080. It will hang for a bit then return an error "Sorry, an error occurred while processing your request." because there's no database configured. When you run it with Kubernetes later - it will hook up the database for you and everything should work.

 
## Kubernetes

What's needed

- Kubernetes 1.10 or later cluster
- At least 1 Linux amd64 node, and 1 Windows amd64 node
- kubectl
- The files at k8s/* in this repo

### Steps to deploy - with Helm

The [Helm](https://helm.sh/) package manager is the easiest way to deploy this app. After you've installed Helm, follow the steps at [charts/fabrikamfiber/README.md](charts/fabrikamfiber/README.md)

### Steps to deploy - manual

This will create 2 deployments - one for web, one for the database, along with a shared secret. 
 
Description                         | Deployment Name              | Service
------------------------------------|------------------------------|-------------------------
Web site behind Azure load balancer | fabrikamfiber.web            | fabrikamfiberweb
SQL Server express database         | db                           | db
 
All 4 can be deployed using these steps:
 
```bash
kubectl apply -n ff -f k8s/db-secret.yaml
kubectl apply -n ff -f k8s/db-mssql-linux.yaml
kubectl apply -n ff -f k8s/db-service.yaml
kubectl apply -n ff -f k8s/fabrikamfiber.web-deployment.yaml
kubectl apply -n ff -f k8s/fabrikamfiber.web-service.yaml
```

## Other Resources

### Step by Step - Getting Started & Azure Service Fabric

There's a great guide on how to use this to test building Docker containers and deploying them to Azure Service Fabric [here](https://docs.microsoft.com/en-us/azure/service-fabric/service-fabric-host-app-in-a-container).

If you want to try a different orchestrator, follow the steps through the first **Test your container** section, then pick from the next sections here.