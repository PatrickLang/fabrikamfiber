oc delete -n plang1 secret mssql
oc delete -n plang1 route --all
oc delete -n plang1 deploy --all
oc delete -n plang1 svc --all