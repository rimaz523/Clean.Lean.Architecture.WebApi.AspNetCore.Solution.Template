# CLAUDE.md

This file provides guidance to Claude Code (claude.ai/code) when working with code in this repository.

## What this repo is

This repo is a `dotnet new` **solution template** (short name `cla-sln`), published to NuGet as `Clean.Lean.Architecture.WebApi.AspNetCore.Solution.Template`. The repo itself is the template. `.template.config/template.json` sets `sourceName` to `clean-lean-arch-dotnet-api-template`, and the template engine replaces that string with the user's solution name. Don't rename it or hardcode it in new places carelessly. Anything committed here ships to every solution generated from the template.

## Commands

Run these from the repo root unless noted. Target framework: .NET 10 (`net10.0`).

```bash
dotnet build clean-lean-arch-dotnet-api-template.slnx
dotnet run --project src/WebApi            # https://localhost:7292, Swagger UI at /swagger
dotnet format clean-lean-arch-dotnet-api-template.slnx --verify-no-changes   # CI's format check

# EF Core migrations (requires: dotnet tool install --global dotnet-ef)
dotnet ef migrations add "MyMigrationName" --project ./src/Infrastructure/ --startup-project ./src/WebApi/
dotnet ef database update --project ./src/WebApi/

# Local tools (husky, swagger CLI)
dotnet tool restore

# Pack the template (bump the version in the .nuspec first)
nuget pack -NoDefaultExcludes
```

There are no unit test projects. The only tests are the Postman collection in `tests/postman/`.

## Build-time behaviours to know about

- **`swagger.json` is regenerated on every Debug build.** The `CreateSwaggerJson` target in `src/WebApi/WebApi.csproj` runs `dotnet swagger tofile` after the build, writing `src/WebApi/swagger.json`, which is committed. Any change to the API surface changes this file. This needs `dotnet tool restore` to have been run.
- **Windows ARM64:** `WebApi.csproj` forces `RuntimeIdentifier=win-x64` on ARM64, because SQL Server LocalDB only ships x64 native binaries. The IL stays AnyCPU so the ARM64 swagger CLI can still load the dll.
- **Central package management:** all package versions live in `Directory.Packages.props`. A `PackageReference` in a csproj must not have a `Version` attribute.
- **Husky pre-commit hook** (`.husky/pre-commit`) runs `dotnet format` on commit. It still references `clean-lean-arch-dotnet-api-template.sln`, but the solution has since moved to `.slnx`.
- **In Development, startup runs EF migrations and seeds data** (`ApplicationDbContextInitialiser`, called from `Program.cs`). Running the app therefore needs a reachable SQL Server. The default is `(localdb)\mssqllocaldb`, set in `appsettings.json` under `Persistence:SqlServerConnectionString`.

## Architecture

Clean architecture with four projects. Dependencies point inward: `WebApi → Application, Infrastructure`, `Infrastructure → Application`, `Application → Domain`.

- **Domain**: plain entities only (`User`, `BlogPost`).
- **Application**: CQRS with MediatR. Each use case is a folder under `<Feature>/Commands|Queries/<UseCase>/` holding the request and its handler in one file, plus an optional `*Validator.cs` and DTOs. The project defines the interfaces that Infrastructure implements (`Common/Interfaces/Persistence/IApplicationDbContext`, `Common/Interfaces/ApiServices/IJsonPlaceholderApiService`). Global usings in `GlobalUsings.cs` cover AutoMapper, MediatR, FluentValidation and `Domain.Entities`.
- **Infrastructure**: EF Core `ApplicationDbContext` (SQL Server; migrations in `Infrastructure/Migrations`), plus a typed `HttpClient` for jsonplaceholder.typicode.com. That client has a retry handler from `Microsoft.Extensions.Http.Resilience`, configured in `Infrastructure/ConfigureServices.cs`. Its settings bind from the `IntegrationOptions` config section through `IntegrationOptionsSetup`.
- **WebApi**: thin controllers that inherit `ApiControllerBase` and only call `Mediator.Send(...)`. The routes are `api/[controller]`, and request objects usually bind with `[FromQuery]`.

### Request pipeline and cross-cutting concerns

The wiring lives in `Application/ConfigureServices.cs` and `WebApi/Program.cs`:

1. Every MediatR request goes through `LoggingBehaviour`, then `ValidationBehaviour`. The validation behaviour runs every FluentValidation validator for that request type. Validators are registered automatically from the Application assembly, so adding a `*Validator : AbstractValidator<TRequest>` is enough. Failures throw `Application.Common.Exceptions.ValidationException`.
2. `WebApi/Infrastructure/GlobalExceptionHandler` maps exceptions to ProblemDetails responses: `ValidationException` becomes 400 and `NotFoundException` becomes 404. It matches the **exact** exception type, so a new exception type, or a subclass of an existing one, needs its own entry in the handler dictionary. Anything unmapped falls through to the default handler.
3. `JsonPlaceholderApiService` turns an upstream 404 into a `NotFoundException`. A 404 from the users endpoint can therefore mean either "route not matched" (empty body) or "upstream has no such user" (ProblemDetails body).

### Mapping

AutoMapper profiles are discovered by convention. A DTO implements `IMapFrom<TEntity>`, and `MappingProfile` picks it up through reflection. To customise a mapping, override `Mapping(Profile profile)` on the DTO. No profile registration is needed.
