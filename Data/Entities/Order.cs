using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace EcommSite.Web.Data.Entities;

public class Order
{
    public int Id { get; set; }
    public DateTime PlaceAt { get; set; }

    public List<OrderItem> Items { get; set; } = [];
    [Precision(18, 2)]
    public decimal Total => Items.Sum(item => item.UnitPrice * item.Quantity);
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