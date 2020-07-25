using System;

namespace SalesAPI.Entities
{
    public class Warehouse
    {
        public Guid Id { protected set; get; }
        public int Quantity { set; get;}
        public string Locality { set; get; }
        public string Type { set; get; }

        public Inventory Inventory { set; get; }

        public Warehouse(Inventory inventory, int quantity, string locality, string type)
        {
            Inventory = inventory;
            Quantity = quantity;
            Locality = locality;
            Type = type;
            Id = Guid.NewGuid();
        }
    }
}
