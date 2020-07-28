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

            warehouses.Add(new Warehouse(12, "SP", "ECOMMERCE"));
            warehouses.Add(new Warehouse(3, "MOEMA", "PHYSICAL_STORE"));

            Inventory inventory = new Inventory(warehouses);

            Assert.NotEqual(inventory.Id, Guid.Empty);
            Assert.Equal(warehouses, inventory.Warehouses);
            Assert.Equal(15, inventory.Quantity);
        }
    }
}
