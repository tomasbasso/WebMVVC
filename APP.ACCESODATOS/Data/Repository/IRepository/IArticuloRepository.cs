
using APP.MODELO;

namespace APP.ACCESODATOS.Data.Repository.IRepository
{
    public interface IArticuloRepository : IRepository<Articulo>
    {
        //IEnumerable<SelectListItem> GetAll(); // Método que devuelve IEnumerable<SelectListItem>
        void Update(Articulo articulo);
        //void Get (Articulo articulo);
        //void Add (Articulo articulo);
        //Articulo Get(int id);
    }
}
