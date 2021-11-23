using Sena.core.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sena.core.Interfaces.IServices
{
    public interface IReservationService
    {
        IEnumerable<ReservaDto> GetReservations();
        ReservaDto GetReservation(int id);
        Task<ReservaDto> SaveReservation(ReservaDto reserva);
        Task<ReservaDto> UpdateReservation(int id, ReservaDto reserva);
        Task<ReservaDto> DeleteReservation(int id);
    }
}
