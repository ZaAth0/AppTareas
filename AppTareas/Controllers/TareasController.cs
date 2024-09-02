using AppTareas.Models;
using Microsoft.AspNetCore.Mvc;

namespace AppTareas.Controllers
{
    public class TareasController : Controller
    {
        //declaramos variables a nivel de clase
        private static List<Tarea> listaTareas = new List<Tarea>();
        private static int nexId = 1;
        public IActionResult Index()
        {

            return View(listaTareas);
        }
        public IActionResult Detalle(int id)
        {
            Tarea? tarea = listaTareas.FirstOrDefault(x => x.Id == id);

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
        public IActionResult Crear(Tarea tarea)
        {
            if (ModelState.IsValid)
            {
                tarea.Id = nexId++;
                listaTareas.Add(tarea);
                return RedirectToAction(nameof(Index));

            }
            return View(tarea);

        }
        [HttpGet]
        public IActionResult Editar(int id)
        {
            Tarea? tarea = listaTareas.FirstOrDefault(x => x.Id == id);

            if (tarea == null)
            {
                return NotFound();
            }

            return View(tarea);
        }

        [HttpPost]
        public IActionResult Editar(Tarea tarea)
        {
            if (ModelState.IsValid)
            {
                var tareaExistente = listaTareas.FirstOrDefault(x => x.Id == tarea.Id);
                if (tareaExistente != null)
                {
                    tareaExistente.Titulo = tarea.Titulo;
                    tareaExistente.Descripcion = tarea.Descripcion;
                    tareaExistente.EstaCompletado = tarea.EstaCompletado;
                }
                return RedirectToAction(nameof(Index));
            }
            return View(tarea);
        }

        [HttpGet]
        public IActionResult Eliminar(int id)
        {
            Tarea? tarea = listaTareas.FirstOrDefault(x => x.Id == id);
            if (tarea == null)
            {
                return NotFound();
            }
            return View(tarea);
        }

        [HttpPost, ActionName("Eliminar")]
        public IActionResult EliminarConfirmado(int id)
        {
            Tarea? tarea = listaTareas.FirstOrDefault(x => x.Id == id);

            if (tarea != null)
            {
                listaTareas.Remove(tarea);
            }

            return RedirectToAction(nameof(Index));
        }



    }
}

