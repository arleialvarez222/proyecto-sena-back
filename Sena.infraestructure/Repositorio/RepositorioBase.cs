using Sena.core.Interfaces.Repository;
using Sena.infraestructure.Data;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Sena.infraestructure.Repositorio
{
    
    public class RepositorioBase<T> : IRepositorio<T> where T : class, new()
    {
        public AngeeContext DatabaseContext { get; set; }

        public RepositorioBase(AngeeContext context)
        {
            DatabaseContext = context;
        }

        public IQueryable<T> Consultas()
        {
            var modeloset = DatabaseContext.Set<T>();
            return modeloset.AsQueryable();
        }
        public T ConsultaPorId(Expression<Func<T, bool>> predicado)
        {
            return Consultas().FirstOrDefault(predicado);
        }

        public T GetSingle(Expression<Func<T, bool>> predicate)
        {
            return Consultas().FirstOrDefault(predicate);
        }

        public async Task Crear(T modelo)
        {
            await DatabaseContext.AddAsync(modelo);
            await DatabaseContext.SaveChangesAsync();

        }

        public IQueryable<T> ConsultaPor(Expression<Func<T, bool>> predicado)
        {
            return Consultas().Where(predicado);
        }
        public async Task Actualizar(T modelo)
        {
            var actualizarT = modelo.GetType().GetProperty("TiempoModi");
            if (actualizarT != null) modelo.GetType().GetProperty("TiempoModi").SetValue(modelo, DateTime.Now);
            DatabaseContext.Update(modelo);
            await DatabaseContext.SaveChangesAsync();

        }

        public async Task Eliminar(T modelo)
        {
            var actulizarEli = modelo.GetType().GetProperty("IsDeleted");
            if (actulizarEli != null)
            {
                modelo.GetType().GetProperty("IsDeleted").SetValue(modelo, true);

                var actualizar = modelo.GetType().GetProperty("TiempoEli");
                if (actualizar != null) modelo.GetType().GetProperty("TiempoEli").SetValue(modelo, DateTime.Now);
                DatabaseContext.Update(modelo);
            }
            else
            {
                DatabaseContext.Remove(modelo);
            }
            await DatabaseContext.SaveChangesAsync();
        }
    }
}

