using Sena.core.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sena.core.Interfaces.IServices
{
    public interface IOrderService
    {
        Task<IEnumerable<OrderDto>> GetOrders();
        OrderDto GetOrder(int id);
        Task<RequestOrderDto> SaveOrder(RequestOrderDto order);
        Task<RequestOrderDto> UpdateOrder(int id, RequestOrderDto order);
        Task<OrderDto> DeleteOrder(int id);
    }
}
