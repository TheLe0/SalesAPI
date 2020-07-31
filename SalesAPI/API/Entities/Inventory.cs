using System.Collections.Generic;

namespace API.Entities
{
    public class Inventory : Entity
    {
        public List<Warehouse> Warehouses { set; get; }
        public int Quantity { protected set; get; }
        
        public Inventory(List<Warehouse> warehouse)
        {
            Warehouses = warehouse;

            Quantity = 0;
            foreach(Warehouse w in Warehouses)
            {
                Quantity += w.Quantity;
            }
        }
    }
}
