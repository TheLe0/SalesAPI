using System;
using Xunit;

using API.Entities;

namespace Tests.Entitites
{
    public class InventoryTest
    {
        [Fact]
        public void InstanceObjectTest()
        {
            Warehouse[] warehouseList = { 
                new Warehouse(12, "SP", "ECOMMERCE"),
                new Warehouse(3, "MOEMA", "PHYSICAL_STORE")
            };
            Inventory inventory = new Inventory(warehouseList);

            Assert.NotEqual(inventory.Id, Guid.Empty);
            Assert.Equal(warehouseList, inventory.WarehouseList);
            Assert.Equal(15, inventory.Quantity);
        }
    }
}
