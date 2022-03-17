# API

## Create the API Project

```
dotnet new sln --name api
dotnet new webapi --name api
dotnet sln add api.sln api.csproj
```

## Configure Certs for Local Development

```
dotnet dev-certs https --clean
dotnet dev-certs https --trust
```

## Run the API

```dotnet watch run

```
