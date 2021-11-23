
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Sena.core.DTO;
using Sena.core.filtro;
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
    public class ClientsController : ControllerBase
    {
        private readonly IClientsService _clients;
        public ClientsController(IClientsService cliente)
        {
            _clients = cliente;
        }

        [HttpGet]
        public async Task<IActionResult> Consultas([FromQuery] FiltroClientes filtro)
        {
            var clientes = await _clients.GetClients(filtro);
            return Ok(clientes);
        }

        [HttpGet("{id}")]
        public IActionResult Consulta(int id)
        {
            var cliente = _clients.GetClient(id);
            return Ok(cliente);
        }

        [HttpPost]
        public async Task<IActionResult> Crear(ClientsDto clienteb)
        {
            await _clients.SaveClient(clienteb);
            return Ok(clienteb);

        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateClient(int id, ClientsDto actualizar)
        {
            var result = await _clients.UpdateClient(id, actualizar);
            return Ok(result);

        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _clients.DeleteClient(id);
            return Ok(result);

        }
    }
}
