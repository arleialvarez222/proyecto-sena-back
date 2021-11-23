using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sena.core.DTO
{
    public class EmployeDto
    {
        public int IdEmpleado { get; set; }
        public double SalarioEmpleado { get; set; }
        public string SegSocEmpleado { get; set; }
        public decimal? ComisionEmpleado { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public string Correo { get; set; }
        public int Documento { get; set; }

        //public ICollection<Pedido> Pedidos { get; set; }
        //public ICollection<Reserva> Reservas { get; set; }
    }
}
