using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

using API.Entities;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SalesController : ControllerBase
    {
        private readonly ILogger<SalesController> _logger;

        public SalesController(ILogger<SalesController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Get()
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

            return Ok(product);
        }

        [HttpGet("{id}")]
        public IActionResult Get(int sku)
        {
            List<Warehouse> warehouses = new List<Warehouse>
            {
                new Warehouse(12, "SP", "ECOMMERCE"),
                new Warehouse(3, "MOEMA", "PHYSICAL_STORE")
            };
            Inventory inventory = new Inventory(warehouses);

            var name = "L'Oréal Professionnel Expert Absolut Repair Cortex Lipidium - Máscara de Reconstrução 500g";

            Product product = new Product(sku, name, inventory);

            return Ok(product);
        }

        [HttpPost]
        public IActionResult Post(Product product)
        {
            return Ok("Successfully inserted the new record");
        }

        [HttpPut]
        public IActionResult Put(int sku, Product product)
        {
            return Ok("Successfully updated the  record");
        }

        [HttpDelete]
        public IActionResult Delete(int sku)
        {
            return Ok("Successfully removed the  record");
        }
    }
}
