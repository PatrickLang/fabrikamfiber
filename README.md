# FabrikamFiber

This project was originally started by Richard Hundhausen and distributed on [CodePlex](https://fabrikam.codeplex.com/) as an application for training users in Visual Studio and development practices.

I have archived it here since I frequently use it for examples rebuilding existing applications to run in containers.

## Step by Step - Getting Started & Azure Service Fabric

There's a great guide on how to use this to test building Docker containers and deploying them to Azure Service Fabric [here](https://docs.microsoft.com/en-us/azure/service-fabric/service-fabric-host-app-in-a-container).

If you want to try a different orchestrator, follow the steps through the first **Test your container** section, then pick from the next sections here.

If you have already built the code in Visual Studio, then you can build and run the containers with:

```powershell
docker-compose -f "C:\ignite2017\fabrikamfiber\docker-compose.yml" -f "C:\ignite2017\fabrikamfiber\docker-compose.override.yml" build --no-cache
docker-compose -f "C:\ignite2017\fabrikamfiber\docker-compose.yml" -f "C:\ignite2017\fabrikamfiber\docker-compose.override.yml" up -d
```



### Kubernetes

This will create 2 deployments - one for web, one for the database. This is pretty much a direct translation of the docker-compose files using [kompose](https://github.com/kubernetes/kompose). It's not production secure since passwords are passed in environment variables.

Description                         | Deployment Name              | Service
------------------------------------|------------------------------|-------------------------
Web site behind Azure load balancer | fabrikamfiber.web            | fabrikamfiberweb
SQL Server express database         | db                           | db

All 4 can be deployed using these steps:

```bash
kubectl apply -f db-deployment.yaml
kubectl apply -f db-service.yaml
kubectl apply -f fabrikamfiber.web-deployment.yaml
kubectl apply -f fabrikamfiber.web-service.yaml
```

### Docker Swarm
