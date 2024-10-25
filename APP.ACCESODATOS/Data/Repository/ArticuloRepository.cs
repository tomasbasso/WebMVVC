using APP.ACCESODATOS.Data.Repository.IRepository;
using APP.MODELO;
using APP.ACCESODATOS.Data.Repository;
using Web.Data;


namespace APP.ACCESODATOS.Data.Repository
{
    public class ArticuloRepository : Repository<Articulo>, IArticuloRepository
    {
        private readonly ApplicationDbContext _db;

        public ArticuloRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }
        public void Update(Articulo articulo)
        {
            var objDesdeDb = _db.Articulo.FirstOrDefault(a => a.IdArticulo == articulo.IdArticulo);
            if (objDesdeDb != null)
            {
                objDesdeDb.Nombre = articulo.Nombre;
                objDesdeDb.Descripcion = articulo.Descripcion;
                objDesdeDb.FechaCreacion = articulo.FechaCreacion;
                objDesdeDb.urlImagen = articulo.urlImagen;
                objDesdeDb.IdArticulo = articulo.IdArticulo;
            }
        }
        public void Add(Articulo articulo)
        {
            _db.Articulo.Add(articulo);
            _db.SaveChanges(); // Guarda los cambios en la base de datos
        }

    }
}