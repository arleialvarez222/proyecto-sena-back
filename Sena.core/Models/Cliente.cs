using System;
using System.Collections.Generic;

#nullable disable

namespace Sena.core.Models
{
    public class Cliente
    {
   

        public int IdCliente { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public string Direccion { get; set; }
        public int Telefono { get; set; }
        public string Correo { get; set; }
        public int Documento { get; set; }

        public ICollection<Pedido> Pedidos { get; set; }
    }
}
