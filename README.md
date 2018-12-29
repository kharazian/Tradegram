# HitCommerce
[![Build Status](https://travis-ci.com/Hitasp/HitCommerce.svg?branch=master)](https://travis-ci.com/Hitasp/HitCommerce)

This project is the forked version of the [ABP vNext repository](https://github.com/abpframework/abp) application framework with special changes for eCommerce scenario.

See [the ABP announcement](https://abp.io/blog/abp/Abp-vNext-Announcement) or  [the official web site](https://abp.io/) for more information about ABP vNext.

### Status

This project is in **very early preview** stage and it's not suggested to use it in any type of projects. 

### How to Build

- Run the `build-all.ps1`. It will build all the solutions in this repository.

### Development

#### Pre Requirements

- Visual Studio 2017 15.7.0+

#### ABP Framework

ABP Framework solution is located under the `framework` folder. It has no external dependency. Just open `Volo.Abp.sln` by Visual Studio and start the development.

#### Modules

[Modules](modules/) have their own solutions and have **local references** to the framework. Unfortunately, Visual Studio has some problems with local references to projects those are out of the solution. As a workaround, you should follow the steps below in order to start developing a module/template:

- Disable "*Automatically check for missing packages during build in Visual Studio*" in the Visual Studio options.
- When you open a solution, first run `dotnet restore` in the root folder of the solution.
- When you change a dependency of a project (or any of the dependencies of your projects change their dependencies), run `dotnet restore` again.

### Contribution

HitCommerce is an open source project. Will remain open-source for ever. So, avoid using commercial codes/libraries.

For PRs which made changes to ABP Framework and that not important for eCommerce scenario; please use the [ABP vNext repository](https://github.com/abpframework/abp).
