using Sena.core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sena.core.DTO
{
    public class OrderDto
    {
        public int IdPedido { get; set; }
        public DateTime FechaVentaPedido { get; set; }
        public float MontoFinalPedido { get; set; }
        public string EstadoPedido { get; set; }
        public int IdEmpleado { get; set; }
        public int IdCliente { get; set; }

        public Cliente Cliente { get; set; }
        public Empleado Empleado { get; set; }
    }
}
