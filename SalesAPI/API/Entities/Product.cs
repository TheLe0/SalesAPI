namespace API.Entities
{
    public class Product : Entity
    {
        public int Sku { set; get; }
        public string Name { set; get; }

        private Inventory _inventory;
        public Inventory Inventory 
        {
            set
            {
                _inventory = value;
                Marketable();
            }
            get
            {
                return _inventory;
            }
        }
        public bool IsMarketable { set; get; }

        public void Marketable()
        {
            IsMarketable = (_inventory.Quantity > 0);
        }
    }
}
