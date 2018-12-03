# FabrikamFiber

This project was originally started by Richard Hundhausen and distributed on [CodePlex](https://fabrikam.codeplex.com/) as an application for training users in Visual Studio and development practices.

I have archived it here since I frequently use it for examples rebuilding existing applications to run in containers.

## Step by Step - Getting Started & Azure Service Fabric

There's a great guide on how to use this to test building Docker containers and deploying them to Azure Service Fabric [here](https://docs.microsoft.com/en-us/azure/service-fabric/service-fabric-host-app-in-a-container).

If you want to try a different orchestrator, follow the steps through the first **Test your container** section, then pick from the next sections here.

### Building from the command line
 
 
1. Find "Developer Command Prompt for VS 2017" on the Start menu or by searching
2. Run `msbuild.exe ./FabrikamFiber.CallCenter.sln /P:BuildConfiguration=release /t:Rebuild` - **this only seems to work after you've built in Visual Studio at least once. I'm not sure why**
 
> Note: When building "Debug" in Visual Studio, it doesn't actually put the website code into the container. It's mapped in as a volume. If you want to build a container with everything included, choose the "Release" target before building.
 
Once you built the code in Visual Studio or with msbuild, then CD back to the solution folder, and run
 

```powershell
Remove-Item -Recurse -Force MyCompany.Visitors.Web\bin\Release\Publish
msbuild FabrikamFiber.CallCenter.sln /t:clean /p:Configuration=Release
msbuild FabrikamFiber.CallCenter.sln /t:build /p:Configuration=Release /p:PublishProfile=FolderProfile /p:DeployOnBuild=true
cd FabrikamFiber.Web

docker build --no-cache -t ff .
docker run --rm -p 8080:80 -d ff
``` 
> Note: When you want to update the Windows and .Net container layers later, run `docker pull` on the base image given in the Dockerfile. In this case, it's `microsoft/aspnet:4.7.1-windowsservercore-1709`



 
## Kubernetes
 
This will create 2 deployments - one for web, one for the database. This is pretty much a direct translation of the docker-compose files using [kompose](https://github.com/kubernetes/kompose). It's not production secure since passwords are passed in environment variables.
 
Description                         | Deployment Name              | Service
------------------------------------|------------------------------|-------------------------
Web site behind Azure load balancer | fabrikamfiber.web            | fabrikamfiberweb
SQL Server express database         | db                           | db
 
All 4 can be deployed using these steps:
 
```bash
kubectl apply -n ff -f k8s/db-deployment.yaml
kubectl apply -n ff -f k8s/db-service.yaml
kubectl apply -n ff -f k8s/fabrikamfiber.web-deployment.yaml
kubectl apply -n ff -f k8s/fabrikamfiber.web-service.yaml
```