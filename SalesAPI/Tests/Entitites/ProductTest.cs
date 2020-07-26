using System;
using Xunit;

using API.Entities;

namespace Tests.Entitites
{
    public class ProductTest
    {
        [Fact]
        public void InstanceObjectTest()
        {
            
            var name = "L'Oréal Professionnel Expert Absolut Repair Cortex Lipidium - Máscara de Reconstrução 500g";
            var sku = 43264;

            Product product = new Product(sku, name);

            Assert.Equal(product.Sku, sku);
            Assert.Equal(product.Name, name);
            Assert.NotEqual(product.Id, Guid.Empty);
        }
    }
}