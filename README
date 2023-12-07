## Project structure

The project is structured in the following folders:

*Persistence*: Contains all the configurations of the entities or tables that will be in the database. It also contains the DbContext, which is the one that interacts directly with the database and where all the DbSets of the entities are located.

*Domain*: Contains all the entities and their properties. It also contains the interfaces where the methods of each entity are defined, and then added to the UnitOfWork interface to be able to use this design pattern that implements lazy initiation for resource rendering.

*Application*: Contains the repositories of each entity, which apply GenericRepository, which contains methods that are commonly used in the management of DbSets. These will be commented in more detail in each file.

*Api*: Contains the controllers (These will be commented in more detail in each file) that interact with the external part of the API. Each of them has authentication. It also contains the DTOs that are used in object mapping to return customized objects through the API, mapped through AutoMapper, which is located in /Profiles. It also has the UserService, which is responsible for the authentication and authorization of the application, and finally the Program, which is where all the services of the application are injected and where the application is also started.
Technical specifications

The project is developed in .NET 7.0 using ASP.NET Core 7.0.
The database is a SQL Server database.
The authentication and authorization system is implemented using JWT.
The project uses AutoMapper to map objects.

How to run the project

To run the project, you can use the following command:

dotnet run

This will start the application on the default port, which is 5031.

Make sure change the connection string in appsettings.json Connection string.

ToDos

Add tests.
Improve the documentation.