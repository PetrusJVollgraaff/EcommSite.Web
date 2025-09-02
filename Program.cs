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
        db.Products.AddRange(
            new EcommSite.Web.Data.Entities.Product { Name = "T-Shirt", Description = "Soft cotton tee", Price = 199.00m, ImageUrl = "images/tshirt.jpg" },
            new EcommSite.Web.Data.Entities.Product { Name = "Mug", Description = "Ceramic mug 350ml", Price = 129.00m, ImageUrl = "images/mug.jpg" },
            new EcommSite.Web.Data.Entities.Product { Name = "Cap", Description = "Adjustable baseball cap", Price = 159.00m, ImageUrl = "images/cap.jpg" }
        );
        db.SaveChanges();
    }
}

app.MapStaticAssets();
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
