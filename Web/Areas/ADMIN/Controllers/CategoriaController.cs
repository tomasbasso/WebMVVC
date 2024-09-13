using Microsoft.AspNetCore.Mvc;
using APP.ACCESODATOS.Data.Repository.IRepository;
using Categoria = APP.MODELO.Categoria;

namespace PasajesApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoriaController : Controller
    {
        private readonly IContenedorTrabajo _contenedorTrabajo;
        public CategoriaController(IContenedorTrabajo contenedorTrabajo)
        {
            _contenedorTrabajo = contenedorTrabajo;
        }

        public IActionResult Index()
        {
            return View();
        }

        
        [HttpGet]
        public IActionResult GetAll()
        {
            return Json(new { data = _contenedorTrabajo.Categoria.GetAll() });
        }

        ///CREAR-----------------------------------------------------------


        [HttpGet]
        public IActionResult Create(int id)
        {
            Categoria categoria = new Categoria();
            categoria = _contenedorTrabajo.Categoria.Get(id);
            if (categoria == null)
            {
                return NotFound();
            }
            return View(categoria);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create (Categoria categoria)
        {
            if (!ModelState.IsValid)
            {
                _contenedorTrabajo.Categoria.Add(categoria);
                _contenedorTrabajo.Save();
                return RedirectToAction("Index");
            }
            return View(categoria);
        }

        ///EDITAR-----------------------------------------------------------
        
        [HttpGet]
        public IActionResult Edit(int id)
        {
            Categoria categoria = new Categoria();
            categoria = _contenedorTrabajo.Categoria.Get(id);
            if (categoria == null)
            {
                return NotFound();
            }
            return View(categoria);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Categoria categoria)
        {
            if (!ModelState.IsValid)
            {
                _contenedorTrabajo.Categoria.Update(categoria);
                _contenedorTrabajo.Save();
                return RedirectToAction("Index");
            }
            return View(categoria);
        }


        ///BORRAR-----------------------------------------------------------

        [HttpGet]
        public IActionResult Delete(int id)
        {
            Categoria categoria = new Categoria();
            categoria = _contenedorTrabajo.Categoria.Get(id);
            if (categoria == null)
            {
                return NotFound();
            }
            return View(categoria);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(Categoria categoria)
        {
            if (!ModelState.IsValid)
            {
                _contenedorTrabajo.Categoria.Remove(categoria);
                _contenedorTrabajo.Save();
                return RedirectToAction("Index");
            }
            return View(categoria);
        }


    }
}
