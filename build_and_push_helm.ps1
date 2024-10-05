& minikube -p minikube docker-env --shell powershell | Invoke-Expression
docker build -t localhost:5000/mykube-img .
docker push localhost:5000/mykube-img
helm upgrade weather .\helm
