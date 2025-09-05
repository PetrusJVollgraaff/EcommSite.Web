using Microsoft.EntityFrameworkCore;

namespace EcommSiteWeb.Web.Data.DTOs;

public class ProductWithPrice
{
    public int ProductId { get; set; }
    public string Name { get; set; } = "";
    public string? Description { get; set; }
    public string? ImageUrl { get; set; }

    public bool OnSpecial { get; set; } = false;

    [Precision(18, 2)]
    public decimal NormalPrice { get; set; }

    [Precision(18, 2)]
    public decimal SpecialPrice { get; set; }
}