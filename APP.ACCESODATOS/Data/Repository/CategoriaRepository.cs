using APP.ACCESODATOS.Data.Repository.IRepository;
using APP.MODELO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Web.Data;
using Web.Models;


namespace APP.ACCESODATOS.Data.Repository
{
    internal class CategoriaRepository : Repository<Categoria>, ICategoriaRepository
    {
        private readonly ApplicationDbContext _db;
        public CategoriaRepository (ApplicationDbContext db) : base(db)
        {
            _db = db;
        }
        public void Update (Categoria categoria)
        {
            var objbaseDato=_db.Categoria.FirstOrDefault(x=> x.Id == categoria.Id);
            objbaseDato.Nombre=categoria.Nombre;
            objbaseDato.habilitada= categoria.habilitada;
            _db.SaveChanges();
        }
    }
}
