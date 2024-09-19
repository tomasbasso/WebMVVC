using APP.ACCESODATOS.Data.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.DotNet.Scaffolding.Shared.Messaging;
using Categoria = APP.MODELO.Categoria;

namespace APPnet8.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoriaController : Controller
    {

        private readonly IContenedorTrabajo _contenedorTrabajo;

        public CategoriaController(IContenedorTrabajo contenedorTrabajo)
        {
            _contenedorTrabajo = contenedorTrabajo;
        }
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Categoria categoria)
        {
            if (ModelState.IsValid)
            {
                _contenedorTrabajo.Categoria.Add(categoria);
                _contenedorTrabajo.Save();
                return RedirectToAction("Index");
            }

            return View(categoria);
        }


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
            if (ModelState.IsValid)
            {
                _contenedorTrabajo.Categoria.Update(categoria);
                _contenedorTrabajo.Save();
                return RedirectToAction("Index");
            }

            return View(categoria);
        }

        #region Llamadas a la API
        [HttpGet]
        public IActionResult GetAll()
        {
            var data = _contenedorTrabajo.Categoria.GetAll();
            Console.WriteLine($"GetAll called. Returning {data.Count()} items.");
            return Json(new { data = data });
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var objdesdebase = _contenedorTrabajo.Categoria.Get(id);
            if (objdesdebase == null)
            {
                return Json(new { success = false, message = "Error borrando categoría" });
            }

            _contenedorTrabajo.Categoria.Remove(objdesdebase);
            _contenedorTrabajo.Save();
            return Json(new { success = true, message = "Categoría borrada correctamente" });
        }
        #endregion

    }
}