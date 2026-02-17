# CapitolServicesTechnical

I wanted to demonstrate some of my experience, so I decided to spin up actual workflows and implementations of the tasks that were provided. I think it'll also help show the approach of workspace management that I'm used to. 

The webapp is hosted in Azure. The FizzBuzz endpoint to trigger the Stored Producedure unfortunately won't work, because my free credits in Azure has expired and it costs money to make a database there :) I ended up spinning a local DB to test my work, so you can see the results of that below.

https://capitolservicestechnical-g5a2g3gcasfkedcj.centralus-01.azurewebsites.net

I also created a GitHub repository so that it'd be easier to share the code with others, and also to make it easier for myself to push updates to Azure as I'm testing. Azure has a really streamlined CI/CD integration with GitHub, so I've got an Actions workflow that automatically deploys to Azure when I push to the main branch from my local.

https://github.com/selrach00/CapitolServicesTechnical

# Task 1
- [FizzBuzzService.cs](CapitolServicesTechnical.Services/FizzBuzzService.cs)
- [FizzBuzzTable.sql](FizzBuzzTable.sql)
- Tests in [FizzBuzzTests.cs](CapitolServicesTechnical.Tests/FizzBuzzTests.cs)
- Called in [HomeController.cs](CapitolServicesTechnical/Controllers/HomeController.cs)

## Project Structure
I'm accustomed to working in IoC (Inversion of Control) dotnet patterns. If you aren't familiar with it, it both introduces a separation of concerns between layers of the application and introduces a (usually) convenient way to unit test functions, as shown in [FizzBuzzTests.cs](CapitolServicesTechnical.Tests/FizzBuzzTests.cs).
- **CapitolServicesTechnical** - Main MVC application
- **[CapitolServicesTechnical.Services](CapitolServicesTechnical.Services)** - Business logic layer
- **[CapitolServicesTechnical.Infrastructure](CapitolServicesTechnical.Infrastructure)** - Data access layer
- **[CapitolServicesTechnical.Tests](CapitolServicesTechnical.Tests)** - Unit tests

I ended up spinning up a LocalDB in SQLExpress (https://go.microsoft.com/fwlink/?linkid=866658) with the script below (containing the SQL required for the task) and tested my solutions there with a couple of simple, manual checks. 
```bash
sqlcmd -S localhost\SQLEXPRESS -i FizzBuzzTable.sql
```

Below are query results of confirming working functionality after hitting the /home/FizzBuzz endpoint are as follows. 

### Total Records Count

```bash
sqlcmd -S localhost\SQLEXPRESS -d FizzBuzzDB -Q "SELECT COUNT(*) AS TotalRows FROM FizzBuzzResults"
```

**Result:**
| TotalRows |
|-----------|
| 100       |

### First 20 Entries

```bash
sqlcmd -S localhost\SQLEXPRESS -d FizzBuzzDB -Q "SELECT TOP 20 Id, Result FROM FizzBuzzResults ORDER BY Id"
```

**Result:**
| Id | Result   |
|----|----------|
| 1  | 1        |
| 2  | 2        |
| 3  | Fizz     |
| 4  | 4        |
| 5  | Buzz     |
| 6  | Fizz     |
| 7  | 7        |
| 8  | 8        |
| 9  | Fizz     |
| 10 | Buzz     |
| 11 | 11       |
| 12 | Fizz     |
| 13 | 13       |
| 14 | 14       |
| 15 | FizzBuzz |
| 16 | 16       |
| 17 | 17       |
| 18 | Fizz     |
| 19 | 19       |
| 20 | Buzz     |

## Running Tests

```bash
dotnet test
```

All 5 unit tests validate the FizzBuzz logic without requiring database access.
