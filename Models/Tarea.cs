namespace AppTareas.Models
{
    public class Tarea
    {
        public int Id { get; set; }
        public string Titulo { get; set; } = string.Empty; //Valor  vacìo
        public string Descripcion { get; set; } = string.Empty;
        public bool EstaCompletado { get; set; }

    }
}
