

using System.ComponentModel.DataAnnotations.Schema;

namespace Sena.core.Models
{
    public class Inventario
    {
        public int IdInventario { get; set; }
        public int CantDisponibleProducto { get; set; }
        public int CantMinimaProducto { get; set; }
        //[Column(TypeName="decimal(18,0)")]
        public decimal Precio { get; set; }
        public int IdProducto { get; set; }

        public Producto Producto { get; set; } 
    }
}
