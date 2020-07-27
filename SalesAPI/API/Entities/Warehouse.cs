using System;

namespace API.Entities
{
    public class Warehouse
    {
        public Guid Id { protected set; get; }
        public int Quantity { set; get; }
        public string Locality { set; get; }
        public string Type { set; get; }

        public Warehouse(int quantity, string locality, string type)
        {
            Quantity = quantity;
            Locality = locality;
            Type = type;
            Id = Guid.NewGuid();
        }
    }
}
