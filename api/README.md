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

```
dotnet watch run

```

## Add Entity Framework Core and SqlLite

```
dotnet add api.csproj package Microsoft.EntityFrameworkCore --version 5.0.15
dotnet add api.csproj package Microsoft.EntityFrameworkCore.Design --version 5.0.15
dotnet add api.csproj package Microsoft.EntityFrameworkCore.Sqlite  --version 5.0.15
```

## Install dotnet-ef Tool

```
dotnet tool install --global dotnet-ef --version 5.0.15
```

## Add the Migration

```
dotnet ef migrations add InitialCreate -o Data/Migrations
```

## Apply the Migration

```
dotnet ef database update
```
