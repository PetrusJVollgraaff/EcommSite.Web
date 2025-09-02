# .NET 9 Blazor Web App e-commerce

A simple **.NET 9 Blazor Web App** with **SQLite + EF Core**, built as a demo e-commerce site.

## Features

- Browse products
- Add to cart
- Checkout (saves orders in SQLite)
- EF Core migrations

### Run Locally

```bash
# restore
dotnet restore

# apply migrations
dotnet ef database update

# run
dotnet watch
```
