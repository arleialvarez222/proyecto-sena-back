using Sena.core.DTO;
using Sena.core.filtro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sena.core.Interfaces.IServices
{
    public interface IClientsService
    {
        Task<IEnumerable<ClientsDto>> GetClients(FiltroClientes filtro);
        ClientsDto GetClient(int id);
        Task<ClientsDto> SaveClient(ClientsDto cliente);
        Task<ClientsDto> UpdateClient(int id, ClientsDto cliente);
        Task<ClientsDto> DeleteClient(int id);
    }
}
