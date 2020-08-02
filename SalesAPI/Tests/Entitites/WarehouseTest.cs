using Xunit;

using API.Entities;

namespace Tests.Entitites
{
    public class WarehouseTest
    {
        [Fact]
        public void InstanceObjectTest()
        {
            var quantity = 12;
            var locality = "SP";
            var type = "ECOMMERCE";

            Warehouse warehouse = new Warehouse
            {
                Quantity = quantity,
                Locality = locality,
                Type = type
            };

            Assert.Equal(quantity, warehouse.Quantity);
            Assert.Equal(locality, warehouse.Locality);
            Assert.Equal(type, warehouse.Type);

        }
    }
}
