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

    public class EmployeController : ControllerBase
    {
        private readonly IEmployeService _employe;
        public EmployeController(IEmployeService employe)
        {
            _employe = employe;
        }

        [HttpGet]
        public IActionResult Consultas()
        {
            var employee = _employe.GetEmployes();
            return Ok(employee);
        }

        [HttpGet("{id}")]
        public IActionResult Consulta(int id)
        {
            var employe = _employe.GetEmploye(id);
            return Ok(employe);
        }

        [HttpPost]
        public async Task<IActionResult> Crear(EmployeDto employeb)
        {
            await _employe.SaveEmploye(employeb);
            return Ok(employeb);

        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateEmploye(int id, EmployeDto actualizar)
        {
            var result = await _employe.UpdateEmploye(id, actualizar);
            return Ok(result);

        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _employe.DeleteEmploye(id);
            return Ok(result);

        }
    }
}
