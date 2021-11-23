using System;
using System.Collections.Generic;

#nullable disable

namespace Sena.core.Models
{
    public class Pedido
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
