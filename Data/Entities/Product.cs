
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace EcommSite.Web.Data.Entities;

public class Product
{
    public int Id { get; set; }
    [Required, MaxLength(120)]
    public string Name { get; set; } = "";

    [MaxLength(1000)]
    public string? Description { get; set; } = null;

    [MaxLength(500)]
    public string? ImageUrl { get; set; } = null;

    public bool DeleteYN { get; set; } = false;

    public DateTime AddedDate { get; set; } = DateTime.UtcNow;
    public DateTime? DeletedDate { get; set; } = null;
}

public class Price
{
    public int Id { get; set; }
    [Precision(18, 2)]
    public decimal Value { get; set; }

    public bool SpecialYN { get; set; } = false;

    public DateTime? SpecialDateStart { get; set; } = null;

    public DateTime? SpecialDateEnd { get; set; } = null;

    public bool DeleteYN { get; set; } = false;
    public DateTime AddedDate { get; set; } = DateTime.UtcNow;
    public DateTime? DeletedDate { get; set; } = null;
}

public class ProductsPrices
{
    public int Id { get; set; }
    public Product? Product { get; set; }
    public Price? Price { get; set; }

    public bool DeleteYN { get; set; } = false;

    public DateTime AddedDate { get; set; } = DateTime.UtcNow;
    public DateTime? DeletedDate { get; set; } = null;
}