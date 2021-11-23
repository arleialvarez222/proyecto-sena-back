using Sena.core.Models;


namespace Sena.core.DTO
{
    public class InventoryDto
    {
        public int IdInventario { get; set; }
        public int CantDisponibleProducto { get; set; }
        public int CantMinimaProducto { get; set; }
        public decimal Precio { get; set; }
        public int IdProducto { get; set; }

        public Producto Producto { get; set; } 
    }
}
