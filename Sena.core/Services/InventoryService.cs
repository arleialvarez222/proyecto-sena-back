using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Sena.core.DTO;
using Sena.core.Interfaces.IServices;
using Sena.core.Interfaces.Repository;
using Sena.core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sena.core.Services
{
    public class InventoryService : IInventoryService
    {
        private readonly IRepositorio<Inventario> _repositorio;
        private readonly IMapper _mapper;
        public InventoryService(IRepositorio<Inventario> inventario, IMapper mapper)
        {
            _repositorio = inventario;
            _mapper = mapper;
        }
        public async Task<InventoryDto> DeleteInventory(int id)
        {
            var inventoribd = _repositorio.ConsultaPorId(c => c.IdInventario == id);
            if (inventoribd != null)
            {
                try
                {
                    await _repositorio.Eliminar(inventoribd);
                    var inventoriE = _mapper.Map<InventoryDto>(inventoribd);
                    return inventoriE;
                }
                catch (Exception)
                {
                    throw new Exception("El producto tiene relacion con un servicio no se puede borrar");
                }
            }
            else
            {
                throw new Exception("El producto no existe en la base de datos");
            }
        }

        public InventoryDto GetInventory(int id)
        {
            var inventario = _repositorio.ConsultaPorId(c => c.IdProducto == id);
            if (inventario != null)
            {
                return _mapper.Map<InventoryDto>(inventario);
            }
            else
            {
                throw new Exception("El producto que solicita no existe en la base de datos");
            }
        }

        public async Task<IEnumerable<InventoryDto>> GetInventorys()
        {
            var inventario = await _repositorio.Consultas().Include(x => x.Producto).ToListAsync();
            var inventariodto = _mapper.Map<IEnumerable<InventoryDto>>(inventario);
            return inventariodto;
        }

        public async Task<RequestInventoryDto> SaveInventory(RequestInventoryDto inventoryb)
        {
            var inventario = _mapper.Map<Inventario>(inventoryb);
            await _repositorio.Crear(inventario);
            inventoryb = _mapper.Map<RequestInventoryDto>(inventario);
            return inventoryb;
        }

        public async Task<RequestInventoryDto> UpdateInventory(int id, RequestInventoryDto inventory)
        {
            var inventario = _repositorio.ConsultaPorId(c => c.IdInventario == id);
            if (inventario != null)
            {
                inventario.CantDisponibleProducto = inventory.CantDisponibleProducto;
                inventario.CantMinimaProducto = inventory.CantMinimaProducto;
                inventario.Precio = inventory.Precio;
                inventario.IdProducto = inventory.IdProducto;

                await _repositorio.Actualizar(inventario);
                var inventoryt = _mapper.Map<RequestInventoryDto>(inventario);
                return inventoryt;
            }
            else
            {
                throw new Exception("El cliente que desea actualizar no existe en la base de datos");
            }
        }
    }
}
