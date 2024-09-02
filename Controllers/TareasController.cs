using AppTareas.Models;
using Microsoft.AspNetCore.Mvc;
/*El nombre de la carpeta de Views debe de coincidir con el nombre del controlador c:*/

namespace AppTareas.Controllers
{
    public class TareasController : Controller
    {
        private static List<Tarea> listaTarea = new List<Tarea>();
        private static int nextId = 1;
        public IActionResult Index()  //La vista debe de tener  el nombre del controlador
        {
            return View(listaTarea);

        }
        public IActionResult Detalle(int id)
        {
            Tarea? tarea = listaTarea.FirstOrDefault(x => x.Id == id);
            if (tarea == null)
            {
                return NotFound();
            }
            return View(tarea);
        }
        [HttpGet]
        public IActionResult Crear()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Tarea tarea) {
            if (ModelState.IsValid) {
                tarea.Id = nextId++;
                listaTarea.Add(tarea);
                return RedirectToAction(nameof(Index));
            }
            return View(tarea);
        }

    }
}
