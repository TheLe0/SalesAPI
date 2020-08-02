using System.Collections.Generic;

namespace API.Entities
{
    public class Inventory : Entity
    {
        private List<Warehouse> _warehouses;
        public List<Warehouse> Warehouses 
        { 
            set
            {
                _warehouses = value;
                Quantity = 0;
                foreach (Warehouse w in _warehouses)
                {
                    Quantity += w.Quantity;
                }
            }
            get
            {
                return _warehouses;
            }
        }
        public int Quantity { protected set; get; }
        
    }
}
