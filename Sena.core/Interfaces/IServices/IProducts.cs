
using Sena.core.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sena.core.Interfaces
{
    public interface IProducts
    {
        IEnumerable<ProductDto> GetProductos();
        ProductDto GetProducto(int id);
        Task<ProductDto> CrearProducto(ProductDto producto);
        Task<ProductDto> ActualizarProducto(int id, ProductDto producto);
        Task<ProductDto> EliminarProducto(int id);
    }
}
