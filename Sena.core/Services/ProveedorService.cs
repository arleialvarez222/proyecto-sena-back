using AutoMapper;
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
    public class ProveedorService : IProveedorService
    {
        private readonly IRepositorio<Proveedor> _repositorio;
        private readonly IMapper _mapper;
        public ProveedorService(IRepositorio<Proveedor> proveedor, IMapper mapper)
        {
            _repositorio = proveedor;
            _mapper = mapper;
        }
        public async Task<ProvedorDto> DeleteProveedor(int id)
        {
            var supplierbd = _repositorio.ConsultaPorId(c => c.IdProveedor == id);
            if (supplierbd != null)
            {
                try
                {
                    await _repositorio.Eliminar(supplierbd);
                    var supplierE = _mapper.Map<ProvedorDto>(supplierbd);
                    return supplierE;
                }
                catch (Exception)
                {
                    throw new Exception("El proveedor tiene relacion con un servicio no se puede borrar");
                }
            }
            else
            {
                throw new Exception("El proveedor no existe en la base de datos");
            }
        }

        public ProvedorDto GetProveedor(int id)
        {
            var supplier = _repositorio.ConsultaPorId(c => c.IdProveedor == id);
            if (supplier != null)
            {
                return _mapper.Map<ProvedorDto>(supplier);
            }
            else
            {
                throw new Exception("El proveedor que solicita no existe en la base de datos");
            }
        }

        public IEnumerable<ProvedorDto> GetProveedores()
        {
            var proveedor = _repositorio.Consultas();
            var proveedordto = _mapper.Map<IEnumerable<ProvedorDto>>(proveedor);
            return proveedordto;
        }

        public async Task<ProvedorDto> SaveProveedor(ProvedorDto proveedorb)
        {
            var supplier = _mapper.Map<Proveedor>(proveedorb);
            await _repositorio.Crear(supplier);
            proveedorb = _mapper.Map<ProvedorDto>(supplier);
            return proveedorb;
        }

        public async Task<ProvedorDto> UpdateProveedor(int id, ProvedorDto proveedor)
        {
            var supplier = _repositorio.ConsultaPorId(c => c.IdProveedor == id);
            if (supplier != null)
            {
                //supplier.IdProveedor = proveedor.IdProveedor;
                supplier.NombreProveedor = proveedor.NombreProveedor;
                supplier.Telefono = proveedor.Telefono;
                supplier.Direccion = proveedor.Direccion;
                supplier.Email = proveedor.Email;

                await _repositorio.Actualizar(supplier);
                var suppliers = _mapper.Map<ProvedorDto>(supplier);
                return suppliers;
            }
            else
            {
                throw new Exception("El proveedor que desea actualizar no existe en la base de datos");
            }
        }
    }
}


