# MAUI Client with ASP.Net Server

![Xamarin Chat SignalR Icon](docs/icon.png)

|:warning: WARNING|
|:---------------------------|
|Don't use this branch for production|

# Requirements
- **dotnet 6.0**, You can use [Visual Studio 2022 Preview](https://visualstudio.microsoft.com/vs/preview/) or install [dotnet-6.0 sdk and runtime](https://dotnet.microsoft.com/en-us/download/dotnet/6.0) and use your favorite editor like [Visual Studio Code](https://code.visualstudio.com/) (Required)
- [PostgreSQL (Npgsql)](https://www.postgresql.org/) or your preferred database engine (Required)
- [pgAdmin](https://www.pgadmin.org/) to view and edit the PostgreSQL database (optinal)

# Usage
## Client
1. Install the MAUI preview package when installing the Visual Studio 2022 Preview
2. Inside the project apply this command in the developer console in Visual Studio when you first launch the project
```
dotnet restore
``` 

## Server
1. Create **appsettings.json** (Production) and **appsettings.Development.json** (Development) files in the server project root then set the "Build Action" to "Content" and "Copy to Output Directory" to "Copy if newer" for each file.
- Paste these into **appsettings.json** and configure your connection parameters
```
{
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft": "Warning",
      "Microsoft.Hosting.Lifetime": "Information"
    }
  },
  "Serilog": {
    "WriteTo": [
      {
        "Name": "File",
        "Args": {
          "path": "log.txt",
          "rollingInterval": "Day"
        }
      },
      {
        "Name": "Console",
        "Args": {
          "theme": "Serilog.Sinks.SystemConsole.Themes.AnsiConsoleTheme::Code, Serilog.Sinks.Console",
          "outputTemplate": "[{Timestamp:HH:mm:ss} {Level:u3}] {Message:lj} <s:{SourceContext}>{NewLine}{Exception}"
        }
      }
    ]
  },
  "ConnectionStrings": {
    "DefaultConnection": "Server=localhost;Port=5432;User Id=postgres;Password=yourpassowrd;Database=mobilechatdb;"
  }
}
```
- Paste these into **appsettings.Development.json** and configure your connection parameters
```
{
  "DetailedErrors": true,
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft": "Warning",
      "Microsoft.Hosting.Lifetime": "Information"
    }
  },
  "ConnectionStrings": {
    "DefaultConnection": "Server=localhost;Port=5432;User Id=postgres;Password=yourpassowrd;Database=mobilechatdb;"
  }
}

```
2. Set your database connection strings in **appsettings.json** and **appsettings.Development.json**
3. Test your database connection, in the Package Manager Console (Ctrl+`)
```
Add-Migration [your migration name]
```
4. Updating the database is automated from the code but you can test it manually
```
Update-Database
```
If your database is setup correctly you should find the database along with your models tables added to it.

---

#### :grey_exclamation: Notice
This project is under heavy refactoring and development, You may contribute once a release is published.
