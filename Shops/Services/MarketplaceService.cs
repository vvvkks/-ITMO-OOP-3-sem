using Shops.Entities;
using Shops.Expection;

namespace Shops.Services;
public class MarketplaceService : IMarketplaceService
{
    private List<Shop> _shops = new List<Shop>();
    private List<Buyer> _buyers = new List<Buyer>();
    private int _buyerId = 1;
    private int _shopId = 1;
    public Buyer AddBuyer(string name, decimal money)
    {
        if (name == null)
            throw new ShopsExpection("Wrong name");
        var buyer = new Buyer(name, money, _buyerId);
        _buyerId++;
        _buyers.Add(buyer);
        return buyer;
    }

    public Shop AddShop(string name, string address)
    {
        if (name == null)
            throw new ShopsExpection("Wrong name");
        if (address == null)
            throw new ShopsExpection("Wrong address");
        var shop = new Shop(name, address, _shopId);
        _shopId++;
        _shops.Add(shop);
        return shop;
    }

    public Product GetProduct(Shop shop, string name)
    {
        Product yourProduct = shop.Products.Single(p => p.ProductName == name);
        return yourProduct;
    }

    public void AddProduct(List<Product> products, Shop shop)
    {
        shop.AddProduct(products);
    }

    public void ChangePriceProduct(Shop shop, string name, decimal newPrice)
    {
        shop.ChangePrice(name, newPrice);
    }

    public Shop FindCheapestProduct(List<Product> products)
    {
        if (products == null)
            throw new ShopsExpection("Wrong products");

        var selectedShops = _shops.Where(shop => shop.ContainsAllProduct(products)).ToList();

        if (selectedShops.Count == 0)
            throw new ShopsExpection("Wrong Shop");

        decimal sum = decimal.MaxValue;
        Shop? selectedShop = null;

        foreach (Shop shop in selectedShops)
        {
            decimal sumProducts = products.Sum(product => shop.Products.Single(p => p.ProductName == product.ProductName).Price);

            if (sumProducts >= sum) continue;
            sum = sumProducts;
            selectedShop = shop;
        }

        return selectedShop ?? throw new ShopsExpection("Not found");
    }

    public void BuyProduct(Buyer buyer, Shop shop, List<ProductTuple> shopList)
    {
        decimal price = shop.BuyProduct(shopList);
        Buyer client = buyer.SpendMoney(price, buyer);
    }
}
