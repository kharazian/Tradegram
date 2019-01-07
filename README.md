# Tradegram
Modular Trade Platform 

[![Build Status](https://travis-ci.com/Hitasp/HitCommerce.svg?branch=master)](https://travis-ci.com/Hitasp/HitCommerce)

This project is the forked version of the
[ABP vNext](https://github.com/abpframework/abp) repository with special changes for eCommerce scenario.

See
[the ABP announcement](https://abp.io/blog/abp/Abp-vNext-Announcement)
or [the official web site](https://abp.io/) for more information about
ABP vNext.

### Status

This project is in **very early preview** stage and it's not suggested
to use it in any type of projects.

### How to Build

- Run the `build-all.ps1`. It will build all the solutions in this
  repository.

### Development

#### Pre Requirements

- Visual Studio 2017 15.9.0+

### ABP Framework

ABP Framework solution is located under the `framework` folder. It has
no external dependency. Just open `Volo.Abp.sln` by Visual Studio and
start the development.

### Modules

[Modules](modules/) have their own solutions and have **local
references** to the framework. Unfortunately, Visual Studio has some
problems with local references to projects those are out of the
solution. As a workaround, you should follow the steps below in order to
start developing a module/template:

- Disable "*Automatically check for missing packages during build in
  Visual Studio*" in the Visual Studio options.
- When you open a solution, first run `dotnet restore` in the root
  folder of the solution.
- When you change a dependency of a project (or any of the dependencies
  of your projects change their dependencies), run `dotnet restore`
  again.

#### Basic Modules

| Module               |    Status     | Services                                  |   PR assent   |
|:---------------------|:-------------:|:------------------------------------------|:-------------:|
| Account              | In-Developing | Login/Register                            | It's an honor |
| AuditLogging         | In-Developing | Persist audit logs to a database          | It's an honor |
| BackgroundJobs       | In-Developing | Persist background jobs                   | It's an honor |
| Identity             | In-Developing | Manage roles, users and their permissions | It's an honor |
| IdentityServer       | In-Developing | Integrates to IdentityServer4             | It's an honor |
| PermissionManagement | In-Developing | Persist permissions                       | It's an honor |
| SettingManagement    | In-Developing | Persist settings                          | It's an honor |
| TenantManagement     | In-Developing | Manage tenants                            | It's an honor |
| Users                | In-Developing | Abstract users for other modules          | It's an honor |

#### Commerce Modules

| Module    |   Status    | Services                                               |   PR assent   |
|:----------|:-----------:|:-------------------------------------------------------|:-------------:|
| Commerce  | In-Progress | Core module for eCommerce modules                      | It's an honor |
| Catalog   | In-Progress | Manage Categories, Product, Manufacturers, Brands, ... |    Future     |
| Basket    |   Pending   | Produce shopping cart                                  |    Future     |
| Marketing |   Pending   | Create campaigns and produce marketing scenarios       |    Future     |
| Ordering  |   Pending   | Manage orders and shipping                             |    Future     |
| Payment   |   Pending   | Produce payment methods                                |    Future     |

#### Additional Modules

| Module   |    Status     | Services                                 |   PR assent   |
|:---------|:-------------:|:-----------------------------------------|:-------------:|
| Common   |  In-Progress  | Abstract Services for additional modules | It's an honor |
| Blogging | In-Developing | Create fancy blogs                       | It's an honor |
| Docs     | In-Developing | Create technical documentation pages     | It's an honor |
| Forums   |    Pending    | Create technical support forums          |    Future     |
| Location |  In-Progress  | GeoLocation providers and services       | It's an honor |

### Roadmap

* Phase 1: *(In-Progress)*
    * Deploy [modules](modules/) as package reference without dependence on each other
    * Deploy [demo app](demo/) 
        * Back-End
        * Front-End
* Phase 2:
    * Code refactoring
    * Apply Local Events and Event Handlers
* Phase 3:
    * Apply Distributed Event (RabbitMQ)
    * Containerizing and Dockerize

### Contribution

HitCommerce is an open source project. Will remain open-source for ever.
So, avoid using commercial codes/libraries.

For PRs which made changes to ABP Framework and that not important for
eCommerce scenario; please use the
[ABP vNext repository](https://github.com/abpframework/abp).
