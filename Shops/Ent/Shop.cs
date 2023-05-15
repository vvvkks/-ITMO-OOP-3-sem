using System.Collections.Generic;
using Shops.Expection;
namespace Shops.Entities;

public class Shop
{
    private List<Product> _products;
    public Shop(string name, string address, int id)
    {
        if (name == null)
            throw new ShopsExpection("Wrong name");
        if (address == null)
            throw new ShopsExpection("Wrong address");
        ShopName = name;
        Address = address;
        Id = id;
        _products = new List<Product>();
    }

    public string ShopName { get; }
    public string Address { get; }
    public int Id { get; }
    public IReadOnlyList<Product> Products => _products;

    public void AddProduct(IReadOnlyList<Product> products)
    {
        foreach (var product in products)
        {
            var productInShop = _products.FirstOrDefault(p => product == p);
            if (productInShop == null)
            {
                _products.Add(product);
            }

            if (productInShop != null) productInShop.Amount += product.Amount;
        }
    }

    public void ChangePrice(string name, decimal price)
    {
        foreach (var product in _products.Where(product => product.ProductName == name))
        {
            product.SetPrice(price);
            return;
        }

        throw new ShopsExpection("Product isn't registered");
    }

    public bool ContainsAllProduct(List<Product> products)
    {
        return products.All(product => _products.Any(x => x.ProductName == product.ProductName));
    }

    public decimal BuyProduct(List<ProductTuple> sellProducts)
    {
        decimal price = 0;
        foreach (ProductTuple sellProduct in sellProducts)
        {
            Product oldProduct = _products.Find(p => p.ProductName == sellProduct.ShopProduct) ??
                                 throw new ShopsExpection("Wrong product");
            if (oldProduct.Amount - sellProduct.ProductAmount < 0) throw new ShopsExpection("Not enough products");
            var changedProduct = new Product(sellProduct.ShopProduct, oldProduct.Price, oldProduct.Amount - sellProduct.ProductAmount);
            _products.Remove(oldProduct);
            _products.Add(changedProduct);
            price = (oldProduct.Price * sellProduct.ProductAmount) + price;
        }

        return price;
    }
}