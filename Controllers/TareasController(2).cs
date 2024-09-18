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
        public IActionResult Editar(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            Tarea? tarea = listaTareas.FirstOrDefault(x => x.Id == id);
            if (tarea == null)
            {
                return NotFound();
            }
            return View(tarea);
        }
        [HttpPost]
        public IActionResult Editar(int id, Tarea tarea)
        {
            if (ModelState.IsValid)
            {
                Tarea? tareaModel = listaTareas.FirstOrDefault(x => x.Id == id);//?=acepta nulo
                if (tareaModel == null)
                {
                    return NotFound();
                }
                tareaModel.Titulo = tarea.Titulo;
                tareaModel.Descripcion = tarea.Descripcion;
                tareaModel.EstaCompletado = tarea.EstaCompletado;

                return RedirectToAction(nameof(Index));

            }
            return View(tarea);
        }
        [HttpGet]
        public IActionResult Eliminar(int? id)
        {
            if (id != null)
            {
                Tarea? tarea = listaTareas.FirstOrDefault(x => x.Id == id);
                if (tarea == null)
                {
                    return NotFound();
                }

                listaTareas.Remove(tarea);
                return RedirectToAction(nameof(Index));

            }
            return RedirectToAction(nameof(Index));

        }

    }
}

