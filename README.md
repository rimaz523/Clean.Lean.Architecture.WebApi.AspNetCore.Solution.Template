## Clean Lean Architecture Solution Template

[![Build Status](https://dev.azure.com/rimazmohommed523/Clean.Lean.Architecture.WebApi.AspNetCore.Solution.Template/_apis/build/status%2FClean.Lean.Architecture.WebApi.Template?branchName=master)](https://dev.azure.com/rimazmohommed523/Clean.Lean.Architecture.WebApi.AspNetCore.Solution.Template/_build/latest?definitionId=22&branchName=master)

### Summary
The objective of this .NET Core template is to expedite the process for developers to swiftly establish a .NET Core Web API project that adheres to clean architecture principles.

If you find this project useful, please give it a star on [github](https://github.com/rimaz523/Clean.Lean.Architecture.WebApi.AspNetCore.Solution.Template). Thanks! ⭐

### Getting Started
The easiest way to get started is to install the .NET template:

`dotnet new install Clean.Lean.Architecture.WebApi.AspNetCore.Solution.Template`

Once installed, create a new solution using the template.

`dotnet new cla-sln --name YourSolutionName`

**Launch the app:**

`cd <sln-name>\src\WebApi\`
`dotnet run`

#### Configure Database
This solution uses EF Core with SQL Server localDB.
To switch with your SQL server connection string update the following value in `appsettings.json`, or alternatively you can continue to use localDB.
<code>
"Persistence": {
  "SqlServerConnectionString": "Server=(localdb)\\mssqllocaldb;Database=clean-app-db;Trusted_Connection=True;MultipleActiveResultSets=true"
}</code>

**To run a database migration**
`dotnet ef migrations add "MyMigrationName" --project .\src\Infrastructure\ --startup-project .\src\WebApi\`

**To update your database with schema updates**
`dotnet ef database update --project .\src\WebApi\WebApi.csproj`

**Note** that you might need to install dotnet ef tools first before you run db migrations and updates : `dotnet tool install --global dotnet-ef`