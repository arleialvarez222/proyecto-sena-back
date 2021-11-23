using Sena.core.Interfaces.Repository;
using Sena.core.Models;
using Sena.infraestructure.Data;


namespace Sena.infraestructure.Repositorio
{
    public class RepositoryProduct : RepositorioBase<Producto> , IRepositoryProduct
    {
        public RepositoryProduct(AngeeContext context): base(context) { }
    }
}
