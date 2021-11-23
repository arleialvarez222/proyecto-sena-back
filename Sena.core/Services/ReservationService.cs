using AutoMapper;
using Sena.core.DTO;
using Sena.core.Interfaces.IServices;
using Sena.core.Interfaces.Repository;
using Sena.core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sena.core.Services
{
    public class ReservationService : IReservationService
    {
        private readonly IRepositorio<Reserva> _repositorio;
        private readonly IMapper _mapper;
        public ReservationService(IRepositorio<Reserva> reserva, IMapper mapper)
        {
            _repositorio = reserva;
            _mapper = mapper;
        }
        public async Task<ReservaDto> DeleteReservation(int id)
        {
            var reservabd = _repositorio.ConsultaPorId(c => c.IdReserva == id);
            if (reservabd != null)
            {
                try
                {
                    await _repositorio.Eliminar(reservabd);
                    var reservationE = _mapper.Map<ReservaDto>(reservabd);
                    return reservationE;
                }
                catch (Exception)
                {
                    throw new Exception("La reserva tiene relacion con un servicio no se puede borrar");
                }
            }
            else
            {
                throw new Exception("La reserva no existe en la base de datos");
            }
        }

        public ReservaDto GetReservation(int id)
        {
            var reservation = _repositorio.ConsultaPorId(c => c.IdReserva == id);
            if (reservation != null)
            {
                return _mapper.Map<ReservaDto>(reservation);
            }
            else
            {
                throw new Exception("La reserva que solicita no existe en la base de datos");
            }
        }

        public IEnumerable<ReservaDto> GetReservations()
        {
            var reservation = _repositorio.Consultas();
            var reservationdto = _mapper.Map<IEnumerable<ReservaDto>>(reservation);
            return reservationdto;
        }

        public async Task<ReservaDto> SaveReservation(ReservaDto reservab)
        {
            var reserva = _mapper.Map<Reserva>(reservab);
            await _repositorio.Crear(reserva);
            reservab = _mapper.Map<ReservaDto>(reserva);
            return reservab;
        }

        public async Task<ReservaDto> UpdateReservation(int id, ReservaDto reserva)
        {
            var reservation = _repositorio.ConsultaPorId(c => c.IdReserva == id);
            if (reservation != null)
            {
                
                reservation.Domicilio = reserva.Domicilio;
                reservation.Redamar = reserva.Redamar;
                reservation.IdEmpleado = reserva.IdEmpleado;

                await _repositorio.Actualizar(reservation);
                var reserv = _mapper.Map<ReservaDto>(reservation);
                return reserv;
            }
            else
            {
                throw new Exception("La reserva que desea actualizar no existe en la base de datos");
            }
        }
    }
}
