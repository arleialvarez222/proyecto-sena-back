using AutoMapper;
using Sena.core.DTO;
using Sena.core.Interfaces;
using Sena.core.Interfaces.Repository;
using Sena.core.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Sena.core.Services
{
    public class ServicioProducto : IProducts
    {
        
        private readonly IRepositorio<Producto> _repositorio;
        private readonly IMapper _mapper;
        public ServicioProducto(IRepositorio<Producto> producto, IMapper mapper)
        {
            _repositorio = producto;
            _mapper = mapper;
        }

        public IEnumerable<ProductDto> GetProductos()
        {
            var productos = _repositorio.Consultas();
            var productosdto = _mapper.Map<IEnumerable<ProductDto>>(productos);
            return productosdto;
        }

        public ProductDto GetProducto(int id)
        {
            var producto = _repositorio.ConsultaPorId(c => c.IdProducto == id);
            if (producto != null)
            {
                return _mapper.Map<ProductDto>(producto);
            }
            else
            {
                throw new Exception("El producto que solicita no existe en la base de datos" );
            }
        }

        public async Task<ProductDto> CrearProducto(ProductDto productob)
        {
            var producto = _mapper.Map<Producto>(productob);
            await _repositorio.Crear(producto);
            productob = _mapper.Map<ProductDto>(producto);
            return productob;

        }

        public async Task<ProductDto> ActualizarProducto(int id, ProductDto producto)
        {
            var productos = _repositorio.ConsultaPorId(c => c.IdProducto == id);
            if (productos != null)
            {
                productos.NombreProducto = producto.NombreProducto;
                productos.DescribProducto = producto.DescribProducto;

                await _repositorio.Actualizar(productos);
                var productot = _mapper.Map<ProductDto>(productos);
                return productot;
            }
            else
            {
                throw new Exception( "El cliente que desea actualizar no existe en la base de datos" );
            }
        }

        public async Task<ProductDto> EliminarProducto(int id)
        {
            var productobd = _repositorio.ConsultaPorId(c => c.IdProducto == id);
            if (productobd != null)
            {
                try
                {
                    await _repositorio.Eliminar(productobd);
                    var productoE = _mapper.Map<ProductDto>(productobd);
                    return productoE;
                }
                catch (Exception)
                {
                    throw new Exception( "El producto tiene relacion con un servicio no se puede borrar" );
                }
            }
            else
            {
                throw new Exception("El cliente no existe en la base de datos" );
            }
        }
    }
}
