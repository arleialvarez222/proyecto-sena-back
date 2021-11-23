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
    public class OrderService : IOrderService
    {
        private readonly IRepositorio<Pedido> _repositorio;
        private readonly IMapper _mapper;

        public OrderService(IRepositorio<Pedido> order, IMapper mapper)
        {
            _repositorio = order;
            _mapper = mapper;
        }
        public async Task<OrderDto> DeleteOrder(int id)
        {
            var orderbd = _repositorio.ConsultaPorId(c => c.IdPedido == id);
            if (orderbd != null)
            {
                try
                {
                    await _repositorio.Eliminar(orderbd);
                    var orderE = _mapper.Map<OrderDto>(orderbd);
                    return orderE;
                }
                catch (Exception)
                {
                    throw new Exception("El pedido tiene relacion con un servicio no se puede borrar");
                }
            }
            else
            {
                throw new Exception("El pedido no existe en la base de datos");
            }
        }

        public OrderDto GetOrder(int id)
        {
            var order = _repositorio.ConsultaPorId(c => c.IdPedido == id);
            if (order != null)
            {
                return _mapper.Map<OrderDto>(order);
            }
            else
            {
                throw new Exception("El pedido que solicita no existe en la base de datos");
            }
        }

        public async Task<IEnumerable<OrderDto>> GetOrders()
        {
            var orders = await _repositorio.Consultas().Include(x => x.Cliente).Include(x => x.Empleado).ToListAsync();
            var ordersdto = _mapper.Map<IEnumerable<OrderDto>>(orders);
            return ordersdto;
        }

        public async Task<RequestOrderDto> SaveOrder(RequestOrderDto orderb)
        {
            var order = _mapper.Map<Pedido>(orderb);
            await _repositorio.Crear(order);
            orderb = _mapper.Map<RequestOrderDto>(order);
            return orderb;
        }

        public async Task<RequestOrderDto> UpdateOrder(int id, RequestOrderDto order)
        {
            var orders = _repositorio.ConsultaPorId(c => c.IdPedido == id);
            if (orders != null)
            {
                orders.FechaVentaPedido = order.FechaVentaPedido;
                orders.MontoFinalPedido = order.MontoFinalPedido;
                orders.EstadoPedido = order.EstadoPedido;
                orders.IdEmpleado = order.IdEmpleado;
                orders.IdCliente = order.IdCliente;

                await _repositorio.Actualizar(orders);
                var ordersTT = _mapper.Map<RequestOrderDto>(orders);
                return ordersTT;
            }
            else
            {
                throw new Exception("El pedido que desea actualizar no existe en la base de datos");
            }
        }
    }
}
