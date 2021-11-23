using System;
using System.Collections.Generic;

#nullable disable

namespace Sena.core.Models
{
    public class Reserva
    {
        public int IdReserva { get; set; }
        public string Domicilio { get; set; }
        public string Redamar { get; set; }
        public int IdEmpleado { get; set; }

        public Empleado Empleado { get; set; } 
    }
}
