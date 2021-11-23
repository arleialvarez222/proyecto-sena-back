using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Sena.core.filtro;
using Sena.core.Interfaces.Repository;
using Sena.core.Models;
using Sena.infraestructure.Data;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sena.infraestructure.Repositorio
{
    public class RepositorioClientes : RepositorioBase<Cliente>, IRepositorioClientes
    {


        private readonly IMapper _mapper;
        public AngeeContext _AngeeContext { get; set; }
        public RepositorioClientes(AngeeContext context, IMapper mapper) : base(context)
        {
            _AngeeContext = context;
            _mapper = mapper;
        }
        public async Task<IEnumerable<Cliente>> ConsultaData(FiltroClientes filtro)
        {
            var clientes = await _AngeeContext.Cliente.ToListAsync();

            if (filtro.Documento != null)
            {
                clientes = clientes.Where(x => x.Documento == filtro.Documento).ToList();
            }


            return clientes;
        }
    }
}
