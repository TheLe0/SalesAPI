using System;
using System.Collections.Generic;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

using API.DAO;
using API.Entities;
using API.Exceptions;

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
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Get()
        {
            return BadRequest("List all products is not allowed! Please inform a Sku.");
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
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Post(Product product)
        {
            if (ProductDAO.Exists(product.Sku))
            {
                return BadRequest("The Sku is already in use!");
            }

            foreach(Warehouse w in product.Inventory.Warehouses)
            {
                WarehouseDAO.CreateRecord(w, product.Sku);
            }

            ProductDAO.CreateRecord(product);

            return Ok("Successfully inserted the new record");
        }

        [HttpPut]
        public IActionResult Put(int sku, Product product)
        {
            return Ok("Successfully updated the  record");
        }

        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Delete(int sku)
        {
            if (sku > 0)
            {
                if (ProductDAO.Delete(sku) && WarehouseDAO.Delete(sku))
                {
                    return Ok("Successfully removed the  record");
                }
            }

            return BadRequest();
        }
    }
}
