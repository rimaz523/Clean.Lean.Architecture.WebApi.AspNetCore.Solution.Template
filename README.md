## Clean Lean Architecture Solution Template

[![Build Status](https://dev.azure.com/rimazmohommed523/Clean.Lean.Architecture.WebApi.AspNetCore.Solution.Template/_apis/build/status%2FClean.Lean.Architecture.WebApi.Template?branchName=master)](https://dev.azure.com/rimazmohommed523/Clean.Lean.Architecture.WebApi.AspNetCore.Solution.Template/_build/latest?definitionId=22&branchName=master)

#### Summary
The objective of this .NET Core template is to expedite the process for developers to swiftly establish a .NET Core Web API project that adheres to clean architecture principles.

#### This templates currently provides you the following out of the box :
- A dotnet core 9.0 solution built using clean architecture principles.
- Mediatr pipeline with logging, error handling and validation implemented as cross-cutting concerns
- FluentValidation for validating api inputs
- API integration with a 3rd party (https://jsonplaceholder.typicode.com) using HttpClient & Polly for retries.
- Efcore Sql Server implementation with localdb.
- An .editorconfig file for defining consistent code styles
- Husky pre-commit hooks that format code on git commit.


**If you find this project useful, please give it a star on [github](https://github.com/rimaz523/Clean.Lean.Architecture.WebApi.AspNetCore.Solution.Template). Thanks! ⭐**

#### Prerequisites
- .NET 9.0 SDK (https://dotnet.microsoft.com/en-us/download)
- Optionally Visual Studio 2022 or above (https://visualstudio.microsoft.com/downloads/)

#### Getting Started
One of the most straightforward methods to begin is by installing this .NET template using your command line.
```bash
dotnet new install Clean.Lean.Architecture.WebApi.AspNetCore.Solution.Template
```

Once installed, create a new solution using the template.
```bash
dotnet new cla-sln --name YourSolutionName
```

#### Launch the app:
To launch your app, first move to the WebApi project in your solution.
```bash
cd <sln-name>\src\WebApi\
```
Then run the app
```bash
dotnet run
```
![commands to run the app](https://raw.githubusercontent.com/rimaz523/Clean.Lean.Architecture.WebApi.AspNetCore.Solution.Template/master/meta/dotnet_run.png)

Looking at the command output you can see the app is running on https://localhost:7292

Open your browser and go to https://localhost:7292/swagger/ to view your api swagger file.

![swagger](https://raw.githubusercontent.com/rimaz523/Clean.Lean.Architecture.WebApi.AspNetCore.Solution.Template/master/meta/swagger_image.png)

#### Configure Husky Pre-commit Hooks
Before installing husky, you will need to restore it.
```bash
dotnet tool restore
```
Also make sure you have initialized git at the root of your solution
```bash
git init
```
To install husky, run the following command from the root of your solution
```bash
  dotnet husky install
```
You will then notice that whenever you commit your code, husky automatically runs `dotnet format` to ensure your coding styles are consistent and fixes and issues for you. You can find the husky hook in the `<root>/.husky/pre-commit` file


#### Configure Database
This solution uses EF Core with SQL Server localDB.
To switch with your SQL server connection string update the **SqlServerConnectionString** value in `appsettings.json`, or alternatively you can continue to use localDB.

```bash
"Persistence": {
  "SqlServerConnectionString": "Server=(localdb)\\mssqllocaldb;Database=clean-app-db;Trusted_Connection=True;MultipleActiveResultSets=true"
}
```

**To run a database migration**
```bash
dotnet ef migrations add "MyMigrationName" --project .\src\Infrastructure\ --startup-project .\src\WebApi\
```
**To update your database with schema updates**
```bash
dotnet ef database update --project .\src\WebApi\
```

**Note** that you might need to install dotnet ef tools first before you run db migrations and updates : `dotnet tool install --global dotnet-ef`
