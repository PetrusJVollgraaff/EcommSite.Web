using Microsoft.EntityFrameworkCore;
using EcommSite.Web.Data.Entities;

namespace EcommSite.Web.Data;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    public DbSet<Product> Products => Set<Product>();
    public DbSet<Price> Prices => Set<Price>();
    public DbSet<ProductsPrices> ProductsPrices => Set<ProductsPrices>();

    public DbSet<Order> Orders => Set<Order>();
    public DbSet<OrderItem> OrderItems => Set<OrderItem>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        //base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<ProductsPrices>().HasOne(pp => pp.Product).WithMany().OnDelete(DeleteBehavior.Cascade);
        modelBuilder.Entity<ProductsPrices>().HasOne(pp => pp.Price).WithMany().OnDelete(DeleteBehavior.Cascade);

    }
}