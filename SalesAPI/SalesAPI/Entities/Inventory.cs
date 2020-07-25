using System;

namespace SalesAPI.Entities
{
    public class Inventory
    {
        public Guid Id { protected set; get; }
        public Warehouse[] WarehouseList { set; get; }
        public int Quantity { protected set; get; }
        public Product Product { set; get; }

        public Inventory(Warehouse[] warehouse, Product product)
        {
            Id = Guid.NewGuid();
            WarehouseList = warehouse;
            Product = product;

            Quantity = 0;
            for (int i = 0; i <= warehouse.Length; i++)
            {
                Quantity += warehouse[i].Quantity;
            }

            product.Marketable(this);
        }
    }
}
