#!/bin/bash

namespace_opt=""

while getopts "n:" opt; do
    case "$opt" in
    n) namespace_opt="-n $OPTARG"
       ;;
    esac
done

kubectl delete ${namespace_opt} secret mssql
kubectl delete ${namespace_opt} deployment fabrikamfiber.web 
kubectl delete ${namespace_opt} deployment db 
kubectl delete ${namespace_opt} svc fabrikamfiberweb 
kubectl delete ${namespace_opt} svc db 
