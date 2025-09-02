using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace EcommSite.Web.Data.Entities;

public class Order
{
    public int Id { get; set; }
    public DateTime PlacedAt { get; set; } = DateTime.UtcNow;
    public List<OrderItem> Items { get; set; } = [];
    [Precision(18, 2)]
    public decimal Total => Items.Sum(i => i.UnitPrice * i.Quantity);
}

public class OrderItem
{
    public int Id { get; set; }
    public int OrderId { get; set; }
    public Order? Order { get; set; }

    public int ProductId { get; set; }
    public Product? Product { get; set; }

    public int Quantity { get; set; }
    [Precision(18, 2)]
    public decimal UnitPrice { get; set; }
}