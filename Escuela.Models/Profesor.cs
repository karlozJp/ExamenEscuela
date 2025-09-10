using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Escuela.Modelos
{
    public class Profesor
    {
        [Key]
        public int IdProfesor { get; set; }
        [Required(ErrorMessage = "Nombre requerido.")]
        public string? Nombre { get; set; }
        [Required(ErrorMessage = "Apellido requerido.")]
        public string? Apellido { get; set; }

        [Required (ErrorMessage ="DNI requerido")]
        public string? DNI { get; set; }
        [NotMapped]
        public string? mensaje { get; set; } 

    }
}
