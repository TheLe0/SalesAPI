using System.Collections.Generic;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

using API.DAO;
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
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Get(int sku)
        {
            if (sku <= 0)
            {
                return BadRequest("Please inform a Sku!");
            }

            if (!ProductDAO.Exists(sku))
            {
                return BadRequest("No Sku found!");
            }

            List<Warehouse> warehouses = WarehouseDAO.Find(sku);

            Inventory inventory = new Inventory
            {
                Warehouses = warehouses
            };

            Product product = new Product
            {
                Sku = sku,
                Name = ProductDAO.Find(sku),
                Inventory = inventory
            };

            return Ok(product);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Post([FromBody] Product product)
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
        public IActionResult Put(int sku, [FromBody] Product product)
        {
            if (sku <= 0)
            {
                return BadRequest("Please inform a Sku!");
            }

            if (!ProductDAO.Exists(sku))
            {
                return BadRequest("The Sku is already in use!");
            }

            WarehouseDAO.Delete(sku);

            foreach(Warehouse w in product.Inventory.Warehouses)
            {
                WarehouseDAO.CreateRecord(w, sku);
            }

            if (ProductDAO.Update(product))
            {
                return Ok("Successfully updated the  record");
            }

            return BadRequest("Error while updating record!");
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
