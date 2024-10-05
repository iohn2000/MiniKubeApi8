# do env vars
& minikube -p minikube docker-env --shell powershell | Invoke-Expression
$dashboard = Start-Job -ScriptBlock { minikube dashboard }
$forward = Start-Job -ScriptBlock { kubectl port-forward --namespace kube-system service/registry 5000:80 }
$tunnel = Start-Job -ScriptBlock { minikube tunnel }
$registry = Start-Job -ScriptBlock { Start-Process "msedge.exe" " http://localhost:5000/v2/_catalog" }
# Get-Job -Id $job.Id
# Stop-Job -Id $job.Id
# Remove-Job -Id $job.Id
