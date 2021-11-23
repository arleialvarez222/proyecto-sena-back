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
    public class ReservationController : ControllerBase
    {
        private readonly IReservationService _reservation;
        public ReservationController(IReservationService reservation)
        {
            _reservation = reservation;
        }

        [HttpGet]
        public IActionResult Consultas()
        {
            var reservation = _reservation.GetReservations();
            return Ok(reservation);
        }

        [HttpGet("{id}")]
        public IActionResult Consulta(int id)
        {
            var reserv = _reservation.GetReservation(id);
            return Ok(reserv);
        }

        [HttpPost]
        public async Task<IActionResult> SaveSupplier(ReservaDto reservationb)
        {
            await _reservation.SaveReservation(reservationb);
            return Ok(reservationb);

        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateSupplier(int id, ReservaDto actualizar)
        {
            var result = await _reservation.UpdateReservation(id, actualizar);
            return Ok(result);

        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _reservation.DeleteReservation(id);
            return Ok(result);

        }
    }
}
