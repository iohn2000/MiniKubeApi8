& minikube -p minikube docker-env --shell powershell | Invoke-Expression
docker build -t localhost:5000/mykube-img .
docker push localhost:5000/mykube-img

$v =  nbgv get-version -v SemVer1
helm package helm --app-version $v # only helm package can set appVersion

helm upgrade --install weather .\my-minikube-weather-api-0.4.0.tgz --set environment=uat