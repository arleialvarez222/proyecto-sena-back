using Sena.core.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sena.core.Interfaces.IServices
{
    public interface IInventoryService
    {
        Task<IEnumerable<InventoryDto>> GetInventorys();
        InventoryDto GetInventory(int id);
        Task<RequestInventoryDto> SaveInventory(RequestInventoryDto inventory);
        Task<RequestInventoryDto> UpdateInventory(int id, RequestInventoryDto inventory);
        Task<InventoryDto> DeleteInventory(int id);
    }
}
