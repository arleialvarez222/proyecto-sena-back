using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Sena.core.DTO;
using Sena.core.Interfaces;
using Sena.core.Interfaces.Repository;
using System.Threading.Tasks;

namespace Sena.WebApi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProducts _products;
        public ProductsController(IProducts producto)
        {
            _products = producto;
        }

        [HttpGet]
        public  IActionResult Consultas()
        {
            var productos =  _products.GetProductos();
            return Ok(productos);
        }

        [HttpGet("{id}")]
        public IActionResult Consulta(int id)
        {
            var producto = _products.GetProducto(id);
            return Ok(producto);
        }

        [HttpPost]
        public async Task<IActionResult> Crear(ProductDto productob)
        {
            await _products.CrearProducto(productob);
            return Ok(productob);
            
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> ActualizarProducto(int id, ProductDto actualizar)
        {
            var result = await _products.ActualizarProducto(id, actualizar);
            return Ok(result);
            
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Eliminar(int id)
        {
            var result = await _products.EliminarProducto(id);
            return Ok(result);

        }

    }
}
