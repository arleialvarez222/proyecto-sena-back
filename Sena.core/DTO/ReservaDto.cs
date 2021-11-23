using Sena.core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sena.core.DTO
{
    public class ReservaDto
    {
        public int IdReserva { get; set; }
        public string Domicilio { get; set; }
        public string Redamar { get; set; }
        public int IdEmpleado { get; set; }

        //public Empleado IdEmpleadoNavigation { get; set; }
    }
}
