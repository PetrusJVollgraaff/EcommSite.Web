using EcommSite.Web.Data.Entities;

namespace EcommSite.Web.Services;

public class CartItem
{
    public Product Product { get; set; } = default!;
    public int Quantity { get; set; } = 1;
}

public class CartService
{
    private readonly List<CartItem> _items = [];
    public IReadOnlyList<CartItem> Items => _items.AsReadOnly();
    public event Action? OnChange;

    public void Add(Product product, int qty = 1)
    {
        var existing = _items.FirstOrDefault(i => i.Product.Id == product.Id);
        if (existing is null) _items.Add(new CartItem { Product = product, Quantity = Math.Max(1, qty) });
        else existing.Quantity += Math.Max(1, qty);
        OnChange?.Invoke();
    }

    public void UpdateQty(int productId, int qty)
    {
        var it = _items.FirstOrDefault(i => i.Product.Id == productId);
        if (it is null) return;
        if (qty <= 0) _items.Remove(it);
        else it.Quantity = qty;
        OnChange?.Invoke();
    }

    public void Remove(int productId)
    {
        _items.RemoveAll(i => i.Product.Id == productId);
        OnChange?.Invoke();
    }

    public void Clear()
    {
        _items.Clear();
        OnChange?.Invoke();
    }

    public decimal Total => _items.Sum(i => i.Product.Price * i.Quantity);
}
