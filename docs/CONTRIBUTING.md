# Contributing to this project

## Prerequisites

* .Net Core 6.0 SDK
* Nuget cli (https://learn.microsoft.com/en-us/nuget/install-nuget-client-tools)
* Nuget Package Explorer (https://apps.microsoft.com/store/detail/nuget-package-explorer/9WZDNCRDMDM3)

## Developer Setup

Clone the project from the github repo 
`git clone https://github.com/rimaz523/Clean.Lean.Architecture.WebApi.AspNetCore.Solution.Template.git`

Launch the app:

`cd <sln-name>\src\WebApi\`
`dotnet run`

## Creating the nupkg for publishing

* Update the .nuspec file with the new package version
* Update the README.md file with the new package version
* Run the following command from the root of your solution : `nuget pack`

## Installing the created nupkg file

* You can list the existing nupkg installs using `dotnet new uninstall`
* To uninstall a specific package use the uninstall command listed in the information provided by the command above.
* To install a nupkg `dotnet new install <name-of-package>::<version>`
