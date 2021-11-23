using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Sena.core.Interfaces.Repository
{
    public interface IRepositorio<T>
    {
        
            IQueryable<T> Consultas();
            T GetSingle(Expression<Func<T, bool>> predicate);
            T ConsultaPorId(Expression<Func<T, bool>> predicado);
            IQueryable<T> ConsultaPor(Expression<Func<T, bool>> predicado);
            Task Crear(T modelo);
            Task Actualizar(T modelo);
            Task Eliminar(T modelo);
        
    }
}
