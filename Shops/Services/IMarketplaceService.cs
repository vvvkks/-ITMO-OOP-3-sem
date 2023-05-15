using System.Collections.Generic;
using Shops.Entities;

namespace Shops.Services
{
    public interface IMarketplaceService
    {
        Buyer AddBuyer(string name, decimal money);
        Shop AddShop(string name, string address);
        Product GetProduct(Shop shop, string name);
        void AddProduct(List<Product> products, Shop shop);
        void ChangePriceProduct(Shop shop, string name, decimal newPrice);
        Shop FindCheapestProduct(List<Product> products);
        void BuyProduct(Buyer buyer, Shop shop, List<ProductTuple> shopList);
    }
}