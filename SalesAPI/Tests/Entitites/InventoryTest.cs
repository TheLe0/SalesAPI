using System;
using System.Collections.Generic;
using Xunit;

using API.Entities;

namespace Tests.Entitites
{
    public class InventoryTest
    {
        [Fact]
        public void InstanceObjectTest()
        {
            List<Warehouse> warehouses = new List<Warehouse>();
            
            var quantity = 12;
            var locality = "SP";
            var type = "ECOMMERCE";

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

            Assert.Equal(warehouses, inventory.Warehouses);
            Assert.Equal(15, inventory.Quantity);
        }
    }
}
