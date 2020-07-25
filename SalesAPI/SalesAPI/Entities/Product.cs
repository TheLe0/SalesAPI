using System;

namespace SalesAPI.Entities
{
    public class Product
    {
        public Guid Id { protected set; get; }
        public int Sku { set; get; }
        public string Name { set; get; }
        public bool IsMarketable { protected set; get; }

        public Product(int sku, string name)
        {
            Sku = sku;
            Name = name;
            Id = Guid.NewGuid();
        }

        public void Marketable(Inventory inventory)
        {
            IsMarketable = (inventory.Quantity > 0);
        }
    }
}
