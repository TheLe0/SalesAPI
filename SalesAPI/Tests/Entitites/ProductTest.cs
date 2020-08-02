using System.Collections.Generic;
using Xunit;

using API.Entities;

namespace Tests.Entitites
{
    public class ProductTest
    {
        [Fact]
        public void InstanceObjectTest()
        {
            List<Warehouse> warehouses = new List<Warehouse>();

            var quantity = 12;
            var locality = "SP";
            var type = "ECOMMERCE";
            var sku = 43264;
            var name = "L'Oréal Professionnel Expert Absolut Repair Cortex Lipidium - Máscara de Reconstrução 500g";

            Warehouse warehouse = new Warehouse
            {
                Quantity = quantity,
                Locality = locality,
                Type = type
            };

            warehouses.Add(warehouse);

            quantity = 3;
            locality = "MOEMA";
            type = "PHYSICAL_STORE";

            warehouse = new Warehouse
            {
                Quantity = quantity,
                Locality = locality,
                Type = type
            };

            warehouses.Add(warehouse);

            Inventory inventory = new Inventory();
            inventory.Warehouses = warehouses;

            Product product = new Product();

            product.Sku = sku;
            product.Name = name;
            product.Inventory = inventory;

            Assert.Equal(product.Sku, sku);
            Assert.Equal(product.Name, name);
            Assert.Equal(product.Inventory, inventory);
            Assert.True(product.IsMarketable); 
        }
    }
}