
using Sena.core.filtro;
using Sena.core.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Sena.core.Interfaces.Repository
{
    public interface IRepositorioClientes: IRepositorio<Cliente>
    {
        Task<IEnumerable<Cliente>> ConsultaData(FiltroClientes filtro);
    }
}
