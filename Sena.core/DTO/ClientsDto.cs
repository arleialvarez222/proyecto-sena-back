using Sena.core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sena.core.DTO
{
    public class ClientsDto
    {

        public int IdCliente { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public string Direccion { get; set; }
        public int Telefono { get; set; }
        public string Correo { get; set; }
        public int Documento { get; set; }

        //public ICollection<Pedido> Pedidos { get; set; }
    }
}
