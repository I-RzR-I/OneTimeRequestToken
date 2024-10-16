> **Note** This repository is developed using .netstandard2.0.

| Name     | Details |
|----------|----------|
| OneTimeRequestToken | [![NuGet Version](https://img.shields.io/nuget/v/OneTimeRequestToken.svg?style=flat&logo=nuget)](https://www.nuget.org/packages/OneTimeRequestToken/) [![Nuget Downloads](https://img.shields.io/nuget/dt/OneTimeRequestToken.svg?style=flat&logo=nuget)](https://www.nuget.org/packages/OneTimeRequestToken)|

The base idea of the current repository is to provide in some cases a secure way to call application endpoints. So from the repository name, you can understand that the core is to generate a token for every application URL.

In the basic flow, you generate a token for an endpoint, and then before executing a request to the resource, you must add to the header generated token.

In the current implementation request validation is realized with a middleware. By default, middleware will search for a token in every request sent with `HTTP` method = `POST`.
Also, validation will be triggered by a `GET` request if in the HTTP header, the token is found.

To understand more efficiently how you can use available functionalities please consult the [using documentation/file](docs/usage.md).

**In case you wish to use it in your project, u can install the package from <a href="https://www.nuget.org/packages/OneTimeRequestToken" target="_blank">nuget.org</a>** or specify what version you want:

> `Install-Package OneTimeRequestToken -Version x.x.x.x`

## Content
1. [USING](docs/usage.md)
1. [CHANGELOG](docs/CHANGELOG.md)
1. [BRANCH-GUIDE](docs/branch-guide.md)