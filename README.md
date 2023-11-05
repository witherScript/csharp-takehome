# Bakery - Many-to-Many

### By Genesis Scott

A web application that stores and validates information and access privileges for registered and unregistered users. Stores Entity data using EF Core's ORM. 

### Technologies Used
- .NET 6.0
- ASP.NET Core MVC
- Microsoft Identity
- Entity Framework Core
- Bootstrap
- C#
- HTML
- CSS

### Setup/Installation Requirements
1. Ensure .NET SDK and runtime are installed on your machine.
2. Clone this repository to your local machine.

```bash
$ git clone https://github.com/witherScript/csharp-takehome/tree/authentication
```
3. Navigate to the Bakery.Solution directory in your terminal.
4. Touch a file in the Bakery.Solution directory called appsettings.json add the following code, replacing the uid and pwd values with your own username and password for MySQL.

```bash
$ touch appsettings.json
```

```csharp
{
  "ConnectionStrings": {
      "DefaultConnection": "Server=localhost;Port=3306;database=Genesis_Scott;uid=[YOUR-USERNAME];pwd=[YOUR-MYSQL-PASSWORD];"
  }
}
```

5. Run the command ```dotnet restore``` to install necessary packages.
6. Run the command ```dotnet build``` to compile the application.
7. Run ```dotnet ef database update``` to replicate current schema migrations
8. Run ```dotnet run``` to start the server and application.
9. Visit localhost:5000 in your browser to access the application.
10. Follow on-screen prompts.
11. If you come across any difficulties or wish to give feedback, don't hesitate to get in touch or raise an issue on the repository.

## Known Bugs
- Server restart completely manual, Ctrl+C 
## License
If you have queries, feedback, or are interested in contributing to the codebase, feel free to get in touch.

Single point of contact: genesis@evolve-self.org
