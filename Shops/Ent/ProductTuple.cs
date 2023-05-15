namespace Shops.Entities;

public class ProductTuple
{
    public ProductTuple(string name, int amount)
    {
        ShopProduct = name;
        ProductAmount = amount;
    }

    public string ShopProduct { get; }
    public int ProductAmount { get; }
}