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

## Add App Insights Logging

Install the Nuget package:

```
dotnet add package Microsoft.ApplicationInsights.AspNetCore
```

Add the App Insights Key to appsettings.Development.json:

```
"ApplicationInsights": {
    "InstrumentationKey": "[Your App Insights Key]"
  }
```

## Add Auth and Auth
https://www.freecodecamp.org/news/authenticate-and-authorize-apis-in-dotnet5/

