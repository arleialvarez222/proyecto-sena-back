using AutoMapper;
using Sena.core.DTO;
using Sena.core.filtro;
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
    public class ClientService : IClientsService
    {
        private readonly IRepositorioClientes _repositorio;
        private readonly IMapper _mapper;

        public ClientService(IRepositorioClientes cliente, IMapper mapper) 
        {
            _repositorio = cliente;
            _mapper = mapper;
        }

        public async Task<ClientsDto> DeleteClient(int id)
        {
            var clientbd = _repositorio.ConsultaPorId(c => c.IdCliente == id);
            if (clientbd != null)
            {
                try
                {
                    await _repositorio.Eliminar(clientbd);
                    var clientE = _mapper.Map<ClientsDto>(clientbd);
                    return clientE;
                }
                catch (Exception)
                {
                    throw new Exception("El cliente tiene relacion con un servicio no se puede borrar");
                }
            }
            else
            {
                throw new Exception("El cliente no existe en la base de datos");
            }
        }

        public ClientsDto GetClient(int id)
        {
            var client = _repositorio.ConsultaPorId(c => c.IdCliente == id);
            if (client != null)
            {
                return _mapper.Map<ClientsDto>(client);
            }
            else
            {
                throw new Exception("El cliente que solicita no existe en la base de datos");
            }
        }

        public async Task<IEnumerable<ClientsDto>> GetClients(FiltroClientes filtro)
        {
            var clientes = await _repositorio.ConsultaData(filtro);
            var clientesdto = _mapper.Map<IEnumerable<ClientsDto>>(clientes);
            return clientesdto;
        }

        public async Task<ClientsDto> SaveClient(ClientsDto clienteb)
        {
            var client= _mapper.Map<Cliente>(clienteb);
            await _repositorio.Crear(client);
            clienteb = _mapper.Map<ClientsDto>(client);
            return clienteb;
        }

        public async Task<ClientsDto> UpdateClient(int id, ClientsDto cliente)
        {
            var clients = _repositorio.ConsultaPorId(c => c.IdCliente == id);
            if (clients != null)
            {
                //clients.IdCliente = cliente.IdCliente;
                clients.Nombres = cliente.Nombres;
                clients.Apellidos = cliente.Apellidos;
                clients.Direccion = cliente.Direccion;
                clients.Telefono = cliente.Telefono;
                clients.Correo = cliente.Correo;
                clients.Documento = cliente.Documento;

                await _repositorio.Actualizar(clients);
                var clienttt = _mapper.Map<ClientsDto>(clients);
                return clienttt;
            }
            else
            {
                throw new Exception("El cliente que desea actualizar no existe en la base de datos");
            }
        }
    }
}
