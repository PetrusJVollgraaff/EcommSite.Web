
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
    public string? Description { get; set; }

    [Precision(18, 2)]
    public decimal Price { get; set; }

    [MaxLength(500)]
    public string? ImageUrl { get; set; }
}