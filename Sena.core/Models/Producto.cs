using System;
using System.Collections.Generic;

#nullable disable

namespace Sena.core.Models
{
    public class Producto
    {
      

        public int IdProducto { get; set; }
        public string NombreProducto { get; set; }
        public string DescribProducto { get; set; }

        public ICollection<Inventario> Inventarios { get; set; }
    }
}
