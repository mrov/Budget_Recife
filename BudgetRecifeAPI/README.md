# Budget Recife API
This is a sample C#.NET API project that demonstrates the usage of Entity Framework Core (EF Core) for data access.

# Prerequisites

### .NET SDK installed

### Database oracle setup and connection string configured

#### You can set the database connection string into the appsettings.json file inside the main project

# API Endpoints

GET /api/Budget/Monthly - Get budget values by months

GET /api/Budget/ByCategories - Get budget values by categories

GET /api/Budget/BySource - Get budget values by source

##### For more informations run the project and check the swagger https://localhost:7254/swagger/


# Dependencies

ASP.NET Core

Entity Framework Core (InMemory, Oracle extensions for bulkinsert)

Bogus

XUnit

CSV Helper

Moq

# Contributing
Contributions are welcome! If you find any issues or want to add new features, please feel free to submit a pull request.
