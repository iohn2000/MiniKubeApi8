& minikube -p minikube docker-env --shell powershell | Invoke-Expression

kubectl delete secret appsettings-secret-prod
kubectl delete secret appsettings-secret-uat 

kubectl create secret generic appsettings-secret-prod --from-file=secret-prod-config.json=secret-prod-config.json
kubectl create secret generic appsettings-secret-uat --from-file=secret-uat-config.json=secret-uat-config.json
