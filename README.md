# Copy Paste Kit
This repository can be used in future projects for easy-development where it's usually copy-pasted anyways.
## API
Contains all the files usually copy-pasted for ASP.NET Core projects
### Additional files
Contains data for docker-compose (API Gateway, 2 APIs, 2 MSSQL Databases), appsettings.json, and Program.cs (It is not complete, check before copy-paste).
### Contexts
Includes context files, currently only for MSSQL with Entity Framework
### Controllers
Includes an API controller with `POST`, `GET`, `GETALL`, `PUT`, `DELETE` methods requiring minor changes.
### Gateway
Includes ocelot file for setting up API gateway, contains `POST`, `GET`, `GETALL`, `PUT`, `DELETE` methods for single controller.
### Models
Includes a basic data model for use with Entity Framework.
### Repositories
Includes repository interface, and example of implemented repository and cached repository. Repositories contains `POST`, `GET`, `GETALL`, `PUT`, `DELETE` methods, and all is implemented in `ASYNC`.
