using Shops.Expection;

namespace Shops.Entities
{
    public class Buyer
    {
        public const int MinimalMoney = 0;
        private List<Product> _products;

        public Buyer(string name, decimal money, int id)
        {
            if (name == null)
                throw new ArgumentNullException("Wrong buyer name");
            if (money < MinimalMoney)
                throw new ShopsExpection("Not enough money");
            Name = name;
            Money = money;
            _products = new List<Product>();
            Id = id;
        }

        public int Id { get; }
        public string Name { get; }
        public decimal Money { get; private set; }
        public IReadOnlyList<Product> Products => _products;
        public Buyer SpendMoney(decimal productPrice, Buyer client)
        {
            if (Money >= productPrice)
            {
                Money -= productPrice;
            }
            else
            {
                throw new ShopsExpection("Not enough money");
            }

            return client;
        }
    }
}
