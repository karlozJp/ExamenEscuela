using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Escuela.Modelos
{
    public class Inscripcion
    {
        [Key]
        public int IdInscripcion { get; set; }

        public int IdEscuela { get; set; }
        public int IdAlumno { get; set; }

        [ForeignKey("IdEscuela")]
        public Escuela LstEscuela { get; set; } = new Escuela();

        [ForeignKey("IdAlumno")]
        public Alumno LstAlumno { get; set; } = new Alumno();
        public string Mensaje { get; set; } = string.Empty;
    }
}
