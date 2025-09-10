using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Escuela.Modelos
{
    public class Alumno
    {
        [Key]
        public int IdAlumno { get; set; }
        [Required (ErrorMessage ="Nombre requerido.")]
        public string? Nombre { get; set; }
        [Required(ErrorMessage = "Apellido requerido.")]
        public string? Apellido { get; set; }
        [Required (ErrorMessage ="Fecha de nacimiento requerida.")]
        public string? FechaNacimiento { get; set; }
        [Required (ErrorMessage = "Matrícula requerida.")]
        public string? matricula { get; set; }
        [NotMapped]
        public string? Mensaje { get; set; }
    }
}
