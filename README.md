# Using Windsor DI Container with ASP.NET Core

**_Note_:** ASP.Net Core framework is used; but instead of targeting .NET Core, the projects target **.NET 4.6.2 Framework**


## Dependencies
- Castle Windsor (DI Container)
- Castle Windsor MSDependencyInjection (Swapping out built-in DI container for Windsor)
- Castle Windsor WcfFacility (communicating with WCF services)


## Why not target .NET Core 2.0 for the WebApp?

Castle WcfIntegrationFacility nuget package didn't support .NET Standard even though it was compiled to .NET 4.5. Confusing?
Yes. Blame Microsoft for this; but over time this story will get better. When the nuget package is updated to support it, then the **WebApp** project can be updated to support .NET Core 2.0


## After clone update submodules

Please update your submodules before attempting to build.

```git submodule update --init --recursive --remote```
