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
    public class SupplierController : ControllerBase
    {
        private readonly IProveedorService _supplier;
        public SupplierController(IProveedorService supplier)
        {
            _supplier = supplier;
        }

        [HttpGet]
        public IActionResult Consultas()
        {
            var suppliers = _supplier.GetProveedores();
            return Ok(suppliers);
        }

        [HttpGet("{id}")]
        public IActionResult Consulta(int id)
        {
            var supplier = _supplier.GetProveedor(id);
            return Ok(supplier);
        }

        [HttpPost]
        public async Task<IActionResult> SaveSupplier(ProvedorDto proveedorb)
        {
            await _supplier.SaveProveedor(proveedorb);
            return Ok(proveedorb);

        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateSupplier(int id, ProvedorDto actualizar)
        {
            var result = await _supplier.UpdateProveedor(id, actualizar);
            return Ok(result);

        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Eliminar(int id)
        {
            var result = await _supplier.DeleteProveedor(id);
            return Ok(result);

        }
    }
}
