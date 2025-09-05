using Microsoft.EntityFrameworkCore;
using EcommSite.Web.Components;
using EcommSite.Web.Data;
using EcommSite.Web.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

//EF Core + Sqlite
var cs = builder.Configuration.GetConnectionString("Sqlite") ?? "Data Source=app.db";
builder.Services.AddDbContext<AppDbContext>(opt => opt.UseSqlite(cs));


//App services
builder.Services.AddScoped<CartService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseAntiforgery();


// Create & seed DB on startup
using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    db.Database.Migrate();

    if (!db.Products.Any())
    {
        var tshirt = new EcommSite.Web.Data.Entities.Product { Name = "T-Shirt", Description = "Soft cotton tee", ImageUrl = "images/tshirt.jpg" };
        var mug = new EcommSite.Web.Data.Entities.Product { Name = "Mug", Description = "Ceramic mug 350ml", ImageUrl = "images/mug.jpg" };
        var cap = new EcommSite.Web.Data.Entities.Product { Name = "Cap", Description = "Adjustable baseball cap", ImageUrl = "images/cap.jpg" };

        var p1 = new EcommSite.Web.Data.Entities.Price { Value = 199.00m };
        var p2 = new EcommSite.Web.Data.Entities.Price { Value = 129.00m };
        var p3 = new EcommSite.Web.Data.Entities.Price { Value = 159.00m };

        db.ProductsPrices.AddRange(
            new EcommSite.Web.Data.Entities.ProductsPrices { Product = tshirt, Price = p1 },
            new EcommSite.Web.Data.Entities.ProductsPrices { Product = mug, Price = p2 },
            new EcommSite.Web.Data.Entities.ProductsPrices { Product = cap, Price = p3 }
        );

        db.SaveChanges();
    }
}

app.MapStaticAssets();
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
