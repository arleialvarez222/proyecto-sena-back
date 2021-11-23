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
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _order;
        public OrderController(IOrderService order)
        {
            _order = order;
        }

        [HttpGet]
        public async Task<IActionResult> Consultas()
        {
            var orde = await _order.GetOrders();
            return Ok(orde);
        }

        [HttpGet("{id}")]
        public IActionResult Consulta(int id)
        {
            var ordes = _order.GetOrder(id);
            return Ok(ordes);
        }

        [HttpPost]
        public async Task<IActionResult> Crear(RequestOrderDto orderb)
        {
            await _order.SaveOrder(orderb);
            return Ok(orderb);

        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateClient(int id, RequestOrderDto actualizar)
        {
            var result = await _order.UpdateOrder(id, actualizar);
            return Ok(result);

        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _order.DeleteOrder(id);
            return Ok(result);

        }
    }
}
