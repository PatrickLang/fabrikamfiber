# FabrikamFiber

This project was originally started by Richard Hundhausen and distributed on [CodePlex](https://fabrikam.codeplex.com/) as an application for training users in Visual Studio and development practices.

I have archived it here since I frequently use it for examples rebuilding existing applications to run in containers.

## Step by Step - Getting Started & Azure Service Fabric

There's a great guide on how to use this to test building Docker containers and deploying them to Azure Service Fabric [here](https://docs.microsoft.com/en-us/azure/service-fabric/service-fabric-host-app-in-a-container).

If you want to try a different orchestrator, follow the steps through the first **Test your container** section, then pick from the next sections here.


## Building from the command line


1. Find "Developer Command Prompt for VS 2017" on the Start menu or by searching
2. Run `msbuild.exe ./FabrikamFiber.CallCenter.sln /P:BuildConfiguration=release /t:Rebuild`

> Note: When building "Debug" in Visual Studio, it doesn't actually put the website code into the container. It's mapped in as a volume. If you want to build a container with everything included, choose the "Release" target before building.

Once you built the code in Visual Studio or with msbuild, then CD back to the solution folder, and run

```powershell
docker-compose -f "docker-compose.yml" -f "docker-compose.override.yml" build --no-cache
docker-compose -f "docker-compose.yml" -f "docker-compose.override.yml" up -d
```

> Note: When you want to update the Windows and .Net container layers later, run `docker pull` on the base image given in the Dockerfile. In this case, it's `microsoft/aspnet:4.7.1-windowsservercore-1709`

### Kubernetes

This will create 2 deployments - one for web, one for the database. This is pretty much a direct translation of the docker-compose files using [kompose](https://github.com/kubernetes/kompose). It's not production secure since passwords are passed in environment variables.

Description                         | Deployment Name              | Service
------------------------------------|------------------------------|-------------------------
Web site behind Azure load balancer | fabrikamfiber.web            | fabrikamfiberweb
SQL Server express database         | db                           | db

All 4 can be deployed using these steps:

```bash
kubectl apply -n ff -f db-deployment.yaml
kubectl apply -n ff -f db-service.yaml
kubectl apply -n ff -f fabrikamfiber.web-deployment.yaml
kubectl apply -n ff -f fabrikamfiber.web-service.yaml
```

> Need a bug link - dns suffix isn't filled out so the web isn't discovering the db

```none
Ethernet adapter vEthernet (71e9952fd2588121a7e5ec3b14f7382161f0fd3128d1c923a726932f327df003_l2bridge):

   Connection-specific DNS Suffix  . :
   Description . . . . . . . . . . . : Hyper-V Virtual Ethernet Adapter #3
   Physical Address. . . . . . . . . : 00-15-5D-0C-CC-06
   DHCP Enabled. . . . . . . . . . . : No
   Autoconfiguration Enabled . . . . : Yes
   Link-local IPv6 Address . . . . . : fe80::8cdd:d393:1384:e4c8%24(Preferred)
   IPv4 Address. . . . . . . . . . . : 10.244.3.149(Preferred)
   Subnet Mask . . . . . . . . . . . : 255.255.255.0
   Default Gateway . . . . . . . . . : 10.240.0.1
   DNS Servers . . . . . . . . . . . : 10.0.0.10
   NetBIOS over Tcpip. . . . . . . . : Disabled

C:\inetpub\wwwroot>nslookup db
Server:  kube-dns.kube-system.svc.cluster.local
Address:  10.0.0.10

*** kube-dns.kube-system.svc.cluster.local can't find db: Non-existent domain

C:\inetpub\wwwroot>nslookup db.ff.svc.cluster.local
Server:  kube-dns.kube-system.svc.cluster.local
Address:  10.0.0.10

Name:    db.ff.svc.cluster.local
Address:  10.0.246.133
```

#### Issues to resolve before merging

- [ ] Figure out why DNS suffix was missing from pods and remove workarounds
  - Remove `.ff.svc.cluster.local` from web.config
  - Remove `-n ff` from above deployments. It should work in any namespace
- [ ] Use a fixed SQL Server Express image for Windows Server 1709. Right now it's using [my fork](https://github.com/PatrickLang/mssql-docker/tree/windows1709)
  - Replace `patricklang/mssql-server-windows-express:1709-4` with an official image in db-deployment.yml


### OpenShift Origin 3.9

_Prerequisites_

- [oc.exe](https://github.com/openshift/origin/releases/download/v3.9.0/openshift-origin-client-tools-v3.9.0-191fece-windows.zip)
- [kubectl.exe](https://storage.googleapis.com/kubernetes-release/release/v1.10.0/bin/windows/amd64/kubectl.exe)

Steps

```
oc get node
alias oc='oc -n plang1'
oc create -f db-secret.yaml
oc create -f db-deployment.yaml
oc create -f db-service.yaml
oc create -f fabrikamfiber.web-deployment.yaml
oc create -f fabrikamfiber.web-service.yaml
oc create -f fabrikamfiber.web-expose.yaml
```

Teardown

```
oc delete route ff
oc delete service db
oc delete service fabrikamfiberweb
oc delete deployment db
oc delete deployment fabrikamfiber.web
oc delete secret mssql
```