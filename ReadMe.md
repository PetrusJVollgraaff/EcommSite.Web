.NET 9 Blazor Web App e-commerce

Required Packages

dotnet add package Microsoft.EntityFrameworkCore.Sqlite
dotnet add package Microsoft.EntityFrameworkCore.Design
dotnet tool install --global dotnet-ef

Migrations
dotnet ef migrations add InitialCreate
dotnet ef database update

Run the Project
dotnet watch
