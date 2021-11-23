using Sena.core.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sena.core.Interfaces.IServices
{
    public interface IEmployeService
    {
        IEnumerable<EmployeDto> GetEmployes();
        EmployeDto GetEmploye(int id);
        Task<EmployeDto> SaveEmploye(EmployeDto employe);
        Task<EmployeDto> UpdateEmploye(int id, EmployeDto employe);
        Task<EmployeDto> DeleteEmploye(int id);
    }
}
