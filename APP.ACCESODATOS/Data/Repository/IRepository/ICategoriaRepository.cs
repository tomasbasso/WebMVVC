using APP.MODELO;
using System.Web.Mvc;



//Este es un repositorio específico para la entidad Categoria. Hereda de IRepository<Categoria>, 
//por lo que incluye todos los métodos genéricos de CRUD y agrega un método Update para 
//actualizar una categoría en particular.

namespace APP.ACCESODATOS.Data.Repository.IRepository
{
    public interface ICategoriaRepository : IRepository<Categoria>
    {
        void Update(Categoria categoria);

        IEnumerable<SelectListItem> GetListaCategorias();
    
    }


}