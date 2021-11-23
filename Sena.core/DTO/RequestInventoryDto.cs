using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sena.core.DTO
{
    public class RequestInventoryDto
    {
        public int CantDisponibleProducto { get; set; }
        public int CantMinimaProducto { get; set; }
        public decimal Precio { get; set; }
        public int IdProducto { get; set; }
    }
}
