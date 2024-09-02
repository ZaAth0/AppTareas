using System.ComponentModel.DataAnnotations;

namespace AppTareas.Models
{
    public class Tarea
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="El titulo es obligatorio.")]
        public string Titulo { get; set; }= string.Empty;
        [Required(ErrorMessage = "El descripcion es obligatoria.")]
        public string Descripcion { get; set; } = string.Empty;
        public bool EstaCompletado { get; set; }
    }
}
