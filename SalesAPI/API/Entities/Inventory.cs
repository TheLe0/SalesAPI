using System;

namespace API.Entities
{
    public class Inventory
    {
        public Guid Id { protected set; get; }
        public Warehouse[] WarehouseList { set; get; }
        public int Quantity { protected set; get; }
        
        public Inventory(Warehouse[] warehouse)
        {
            Id = Guid.NewGuid();
            WarehouseList = warehouse;

            Quantity = 0;
            for (int i = 0; i <= warehouse.Length; i++)
            {
                Quantity += warehouse[i].Quantity;
            }

        }
    }
}
