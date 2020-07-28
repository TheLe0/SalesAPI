using System;
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

            warehouses.Add(new Warehouse(12, "SP", "ECOMMERCE"));
            warehouses.Add(new Warehouse(3, "MOEMA", "PHYSICAL_STORE"));
            Inventory inventory = new Inventory(warehouses);

            var name = "L'Oréal Professionnel Expert Absolut Repair Cortex Lipidium - Máscara de Reconstrução 500g";
            var sku = 43264;

            Product product = new Product(sku, name, inventory);

            Assert.Equal(product.Sku, sku);
            Assert.Equal(product.Name, name);
            Assert.Equal(product.Inventory, inventory);
            Assert.True(product.IsMarketable); 
            Assert.NotEqual(product.Id, Guid.Empty);
        }
    }
}