using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Escuela.Modelos
{
    public class Escuela
    {
        [Key]
        public int IdEscuela { get; set; }
        [Required (ErrorMessage ="Nombre requerido.")]        
        public string? Nombre { get; set; }
        [Required (ErrorMessage ="Descripción requerida.")]
        public string? Descripcion { get; set; }
        [Required (ErrorMessage ="Código requerido.")]
        public string? Codigo { get; set; }

        [NotMapped]
        public string Mensaje { get; set; } = string.Empty;
    }
}
