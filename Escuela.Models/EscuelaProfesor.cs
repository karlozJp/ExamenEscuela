using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Escuela.Modelos
{
    public class EscuelaProfesor
    {
        [Key]
        public int IdEscuelaProf { get; set; }
        public  int IdEscuela { get; set; }
        public int IdProfesor {  get; set; }
        
        [ForeignKey(nameof(IdEscuela))]
        public Escuela LstEscuela { get; set; } = new Escuela();

        [ForeignKey(nameof(IdProfesor))]
        public Profesor LstProfesor { get; set; } = new Profesor();
        [NotMapped]
        public string Mensaje { get; set; } = string.Empty;

        [NotMapped]
        public Alumno LstAlumno { get; set; } = new Alumno();
    }
}
