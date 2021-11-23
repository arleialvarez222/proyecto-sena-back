using Sena.core.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sena.core.Interfaces.IServices
{
    public interface IProveedorService
    {
        IEnumerable<ProvedorDto> GetProveedores();
        ProvedorDto GetProveedor(int id);
        Task<ProvedorDto> SaveProveedor(ProvedorDto proveedor);
        Task<ProvedorDto> UpdateProveedor(int id, ProvedorDto proveedor);
        Task<ProvedorDto> DeleteProveedor(int id);
    }
}
