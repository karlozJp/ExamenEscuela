using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Escuela.Modelos
{
    public class ProfesorAlumno
    {
        [Key]
        public int IdProfAlum { get; set; }
        public int IdProfesor {  get; set; }
        public int IdInscripcion { get; set; }
        [ForeignKey("IdProfesor")]
        public Profesor LstProfesor { get; set; } = new Profesor();
        [ForeignKey("IdInscripcion")]
        public Inscripcion LstInscripcion { get; set; } = new Inscripcion();
        [NotMapped]
        public string Mensaje { get; set; } = string.Empty;
    }
}
