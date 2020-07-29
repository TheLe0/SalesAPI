using System;

namespace API.Entities
{
    public class Product
    {
        public int Sku { set; get; }
        public string Name { set; get; }
        public Inventory Inventory { protected set; get; }
        public bool IsMarketable { protected set; get; }

        public Product(int sku, string name, Inventory inventory)
        {
            Sku = sku;
            Name = name;
            Inventory = inventory;

            Marketable();
        }

        public void Marketable()
        {
            IsMarketable = (Inventory.Quantity > 0);
        }
    }
}
