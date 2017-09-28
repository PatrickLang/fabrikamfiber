# FabrikamFiber

This project was originally started by Richard Hundhausen and distributed on [CodePlex](https://fabrikam.codeplex.com/) as an application for training users in Visual Studio and development practices.

I have archived it here since I frequently use it for examples rebuilding existing applications to run in containers.

## Step by Step - Getting Started & Azure Service Fabric

There's a great guide on how to use this to test building Docker containers and deploying them to Azure Service Fabric [here](https://docs.microsoft.com/en-us/azure/service-fabric/service-fabric-host-app-in-a-container).

If you want to try a different orchestrator, follow the steps through the first **Test your container** section, then pick from the next sections here.

If you have already built the code in Visual Studio, then you can build and run the containers with:

```powershell
docker-compose -f "C:\ignite2017\fabrikamfiber\docker-compose.yml" -f "C:\ignite2017\fabrikamfiber\docker-compose.override.yml" build
docker-compose -f "C:\ignite2017\fabrikamfiber\docker-compose.yml" -f "C:\ignite2017\fabrikamfiber\docker-compose.override.yml" up -d
```


> Issue: this is currently failing. Use `docker ps` to get the container ID, then `docker exec <containerid> powershell.exe Invoke-WebRequest http://localhost` to see the failure stack

```none
<!--
[HttpCompileException]: (0): error CS0016: Could not write to output file
&#39;c:\Windows\Microsoft.NET\Framework64\v4.0.30319\Temporary ASP.NET
Files\root\e22c2559\92c7e946\App_global.asax.yoqh0stm.dll&#39; -- &#39;The
directory name is invalid. &#39;
   at System.Web.Compilation.AssemblyBuilder.Compile()
   at System.Web.Compilation.BuildProvidersCompiler.PerformBuild()
   at System.Web.Compilation.ApplicationBuildProvider.GetGlobalAsaxBuildResult
Boolean isPrecompiledApp)
   at System.Web.Compilation.BuildManager.CompileGlobalAsax()
   at System.Web.Compilation.BuildManager.EnsureTopLevelFilesCompiled()
   at System.Web.Compilation.BuildManager.CallAppInitializeMethod()
   at System.Web.Hosting.HostingEnvironment.Initialize(ApplicationManager
appManager, IApplicationHost appHost, IConfigMapPathFactory
configMapPathFactory, HostingEnvironmentParameters hostingParameters,
PolicyLevel policyLevel, Exception appDomainCreationException)
[HttpException]: (0): error CS0016: Could not write to output file
&#39;c:\Windows\Microsoft.NET\Framework64\v4.0.30319\Temporary ASP.NET
Files\root\e22c2559\92c7e946\App_global.asax.yoqh0stm.dll&#39; -- &#39;The
directory name is invalid. &#39;
   at System.Web.HttpRuntime.FirstRequestInit(HttpContext context)
   at System.Web.HttpRuntime.EnsureFirstRequestInit(HttpContext context)
   at
System.Web.HttpRuntime.ProcessRequestNotificationPrivate(IIS7WorkerRequest wr,
HttpContext context)
-->
```

### Kubernetes


### Docker Swarm
