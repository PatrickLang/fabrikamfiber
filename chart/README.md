

## Requirements

Topology
- Cluster with at least 1 Windows node
- Linux node - can run Tiller on the master

Install these first:

- Helm, be sure to run `helm init` then make sure `tiller-deploy` is shown in `kubectl get pod -n kube-system`
- Kubernetes Service Catalog - [install steps](https://github.com/kubernetes-incubator/service-catalog/blob/master/docs/install.md)
- Open Service Broker for Azure [install steps](https://github.com/Azure/open-service-broker-azure/tree/master/contrib/k8s/charts/open-service-broker-azure)


TL;DR service catalog

```powershell
helm repo add svc-cat https://svc-catalog-charts.storage.googleapis.com
helm install svc-cat/catalog  --name catalog --namespace catalog
```

Needed to modify deployments

In each of these, add:

```yaml
      nodeSelector:
        beta.kubernetes.io/os: linux
```

`kubectl edit deploy -n catalog catalog-catalog-controller-manager`
`kubectl edit deploy -n catalog catalog-catalog-apiserver`




TL;DR OSBA

 ```powershell
$ENV:AZURE_TENANT_ID="..."
$ENV:AZURE_CLIENT_ID="..."
$ENV:AZURE_CLIENT_SECRET="..."
$ENV:AZURE_SUBSCRIPTION_ID="..."

helm repo add azure https://kubernetescharts.blob.core.windows.net/azure
helm install azure/open-service-broker-azure --name osba --namespace osba --set azure.subscriptionId=$ENV:AZURE_SUBSCRIPTION_ID --set azure.tenantId=$ENV:AZURE_TENANT_ID --set azure.clientId=$ENV:AZURE_CLIENT_ID --set azure.clientSecret=$ENV:AZURE_CLIENT_SECRET`
```

## Remaining Work

- [ ] Test `developerEdition: true`