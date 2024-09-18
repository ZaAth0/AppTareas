using System.ComponentModel.DataAnnotations;

namespace AppTareas.Models
{
    public class Tarea
    {

        //Se agreda validaciones en el modelo
        //Con DataAnnotations
        public int Id { get; set; }
        [Required(ErrorMessage = "El Titulo es obligatorio")]
        public string Titulo { get; set; }= string.Empty;
        [Required(ErrorMessage = "El Descripcion es obligatoria")]
        public string Descripcion { get; set; } = string.Empty;
        public bool EstaCompletado { get; set; }
    }
}
