using APP.ACCESODATOS.Data.Repository.IRepository;
using System;
using APP.MODELO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Web.Data;
using APP.ACCESODATOS;
using System.Web.Mvc;


//Es la implementación de IContenedorTrabajo. Agrupa todos los repositorios en un único 
// objeto y controla la transacción a través del método Save(). En este caso, tienes 
// un repositorio de categorías, pero podrías agregar otros repositorios.

namespace APP.ACCESODATOS.Data.Repository
{
    public class ContenedorTrabajo : IContenedorTrabajo
    {
        private readonly ApplicationDbContext _db;

        public ContenedorTrabajo(ApplicationDbContext db)
        {
            _db = db;
            Categoria = new CategoriaRepository(_db);
            Articulo = new ArticuloRepository(_db); 

        }

        public ICategoriaRepository Categoria { get; private set; }
        public IArticuloRepository Articulo { get; private set; } 

        public void Dispose()
        {
            _db.Dispose();
        }
        public void Update(Categoria categoria)
        {
            var objbaseDato = _db.Categoria.FirstOrDefault(x => x.id == categoria.id);
            objbaseDato.Nombre = categoria.Nombre;
            objbaseDato.habilitada = categoria.habilitada;
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
        public void Save()
        {
            _db.SaveChanges();
        }
    }
}

