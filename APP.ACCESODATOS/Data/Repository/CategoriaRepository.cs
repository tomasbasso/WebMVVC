using APP.ACCESODATOS.Data.Repository.IRepository;
using APP.MODELO;
//using Microsoft.AspNetCore.Mvc.Rendering;
using APP.ACCESODATOS.Data.Repository;
using Web.Data;
using System.Web.Mvc;


//Hereda de Repository<Categoria> y sobreescribe el método Update para actualizar 
//los campos de una categoría específica en la base de datos. Implementa la lógica de negocio que es específica para las categorías.

namespace APP.ACCESODATOS.Data.Repository
{
    public class CategoriaRepository : Repository<Categoria>, ICategoriaRepository
    {
        private readonly ApplicationDbContext _db;

        public CategoriaRepository (ApplicationDbContext db) : base(db)
        {
            _db = db;
        }
        public void Update (Categoria categoria)
        {
            var objbaseDato=_db.Categoria.FirstOrDefault(x=> x.id == categoria.id);
            objbaseDato.Nombre=categoria.Nombre;
            objbaseDato.habilitada= categoria.habilitada;
            _db.SaveChanges();
        }

        public IEnumerable<SelectListItem> GetListaCategorias()
        {
            return _db.Categoria.Select(i => new SelectListItem()
            {
                Text = i.Nombre,
                Value = i.id.ToString()
            });
        }

    }
}
