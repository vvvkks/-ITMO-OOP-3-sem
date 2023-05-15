using Shops.Expection;

namespace Shops.Entities;
public class Product
{
    public const int MinimalPrice = 0;
    public const int MinimumAmountOfProducts = 0;
    public Product(string name, decimal price, int amount)
    {
        if (name == null)
            throw new ArgumentNullException("Wrong name");
        if (price < MinimalPrice)
            throw new ShopsExpection("Wrong price");
        if (amount < MinimumAmountOfProducts)
            throw new ShopsExpection("Wrong count");
        ProductName = name;
        Price = price;
        Amount = amount;
    }

    public string ProductName { get; }
    public decimal Price { get; private set; }
    public int Amount { get; set; }
    public void SetPrice(decimal price)
    {
        if (price < MinimalPrice)
            throw new ShopsExpection("Wrong price");
        Price = price;
    }
}