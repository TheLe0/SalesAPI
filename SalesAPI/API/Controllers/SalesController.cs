using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

using API.Entities;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SalesController : ControllerBase
    {
        private readonly ILogger<SalesController> _logger;

        public SalesController(ILogger<SalesController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public Product Get()
        {
            List<Warehouse> warehouses = new List<Warehouse>
            {
                new Warehouse(12, "SP", "ECOMMERCE"),
                new Warehouse(3, "MOEMA", "PHYSICAL_STORE")
            };
            Inventory inventory = new Inventory(warehouses);

            var name = "L'Oréal Professionnel Expert Absolut Repair Cortex Lipidium - Máscara de Reconstrução 500g";
            var sku = 43264;

            Product product = new Product(sku, name, inventory);

            return product;
        }
    }
}
