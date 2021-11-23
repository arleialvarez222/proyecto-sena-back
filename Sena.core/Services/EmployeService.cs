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
    public class EmployeService : IEmployeService
    {
        private readonly IRepositorio<Empleado> _repositorio;
        private readonly IMapper _mapper;

        public EmployeService(IRepositorio<Empleado> employe, IMapper mapper)
        {
            _repositorio = employe;
            _mapper = mapper;
        }
        public async Task<EmployeDto> DeleteEmploye(int id)
        {
            var employebd = _repositorio.ConsultaPorId(c => c.IdEmpleado == id);
            if (employebd != null)
            {
                try
                {
                    await _repositorio.Eliminar(employebd);
                    var employeE = _mapper.Map<EmployeDto>(employebd);
                    return employeE;
                }
                catch (Exception)
                {
                    throw new Exception("El empleado tiene relacion con un servicio no se puede borrar");
                }
            }
            else
            {
                throw new Exception("El cliente no existe en la base de datos");
            }
        }

        public EmployeDto GetEmploye(int id)
        {
            var employe = _repositorio.ConsultaPorId(c => c.IdEmpleado == id);
            if (employe != null)
            {
                return _mapper.Map<EmployeDto>(employe);
            }
            else
            {
                throw new Exception("El empleado que solicita no existe en la base de datos");
            }
        }

        public IEnumerable<EmployeDto> GetEmployes()
        {
            var employes = _repositorio.Consultas();
            var employesdto = _mapper.Map<IEnumerable<EmployeDto>>(employes);
            return employesdto;
        }

        public async Task<EmployeDto> SaveEmploye(EmployeDto employeb)
        {
            var employe = _mapper.Map<Empleado>(employeb);
            await _repositorio.Crear(employe);
            employeb = _mapper.Map<EmployeDto>(employe);
            return employeb;
        }

        public async Task<EmployeDto> UpdateEmploye(int id, EmployeDto employe)
        {
            var employes = _repositorio.ConsultaPorId(c => c.IdEmpleado == id);
            if (employes != null)
            {
                //clients.IdCliente = cliente.IdCliente;
                employes.SalarioEmpleado = employe.SalarioEmpleado;
                employes.SegSocEmpleado = employe.SegSocEmpleado;
                employes.ComisionEmpleado = employe.ComisionEmpleado;
                employes.Nombres = employe.Nombres;
                employes.Apellidos = employe.Apellidos;
                employes.Direccion = employe.Direccion;
                employes.Telefono = employe.Telefono;
                employes.Correo = employe.Correo;
                employes.Documento = employe.Documento;

                await _repositorio.Actualizar(employes);
                var employeEE = _mapper.Map<EmployeDto>(employes);
                return employeEE;
            }
            else
            {
                throw new Exception("El empleado que desea actualizar no existe en la base de datos");
            }
        }
    }
}
