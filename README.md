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
docker-compose -f "docker-compose.yml" -f "docker-compose.override.yml" build --no-cache
docker-compose -f "docker-compose.yml" -f "docker-compose.override.yml" up -d
```
 
> Note: When you want to update the Windows and .Net container layers later, run `docker pull` on the base image given in the Dockerfile. In this case, it's `microsoft/aspnet:4.7.1-windowsservercore-1709`
