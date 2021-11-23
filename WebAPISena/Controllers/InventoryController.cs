using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Sena.core.DTO;
using Sena.core.Interfaces.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPISena.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class InventoryController : ControllerBase
    {
        private readonly IInventoryService _inventory;
        public InventoryController(IInventoryService inventory)
        {
            _inventory = inventory;
        }

        [HttpGet]
        public async Task<IActionResult> Consultas()
        {
            var inventarios = await _inventory.GetInventorys();
            return Ok(inventarios);
        }

        [HttpGet("{id}")]
        public IActionResult Consulta(int id)
        {
            var inventario = _inventory.GetInventory(id);
            return Ok(inventario);
        }

        [HttpPost]
        public async Task<IActionResult> Crear(RequestInventoryDto inventorydto)
        {
            await _inventory.SaveInventory(inventorydto);
            return Ok(inventorydto);

        }

        [HttpPut("{id}")]
        public async Task<IActionResult> ActualizarProducto(int id, RequestInventoryDto actualizar)
        {
            var result = await _inventory.UpdateInventory(id, actualizar);
            return Ok(result);

        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Eliminar(int id)
        {
            var result = await _inventory.DeleteInventory(id);
            return Ok(result);

        }
    }
}
