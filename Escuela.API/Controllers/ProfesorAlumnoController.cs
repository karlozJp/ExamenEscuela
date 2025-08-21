using Escuela.AccesoDatos.Data.Repository.IRepository;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
namespace Escuela.API.Controllers
{
    [EnableCors("ReglasCors")]
    [Route("api/[controller]")]
    [ApiController]
    public class ProfesorAlumnoController : Controller
    {
        private readonly IContenedorTrabajo _contenedorTrabajo;
        public ProfesorAlumnoController(IContenedorTrabajo contenedorTrabajo)
        {
            _contenedorTrabajo = contenedorTrabajo;
        }
        [HttpGet]
        [Route("Consulta/{idProfesor:int}")]
        public IActionResult Consulta(int idProfesor)
        {
            List<Modelos.ProfesorAlumno> lstProfesorAlumno = new List<Modelos.ProfesorAlumno>();
            try
            {
                lstProfesorAlumno = _contenedorTrabajo.ProfesorAlumno.Consulta(idProfesor);
                if (lstProfesorAlumno.Count > 0)
                    return StatusCode(StatusCodes.Status200OK, new { mensaje = "ok", response = lstProfesorAlumno });
                else
                    return StatusCode(StatusCodes.Status406NotAcceptable, new { mensaje = "No se encontró información.", response = lstProfesorAlumno });
            }
            catch (Exception error)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { mensaje = error.Message, response = lstProfesorAlumno });
            }
        }
        [HttpPost]
        [Route("Inserta")]
        public IActionResult Inserta([FromBody] Modelos.ProfesorAlumno entProfesorAlumno)
        {
            Modelos.ProfesorAlumno profesorAlumno = new Modelos.ProfesorAlumno();
            if (entProfesorAlumno == null)
            {
                return StatusCode(StatusCodes.Status404NotFound, new { mensaje = "Error al crear la relación profesor-alumno" });
            }
            try
            {
                profesorAlumno = _contenedorTrabajo.ProfesorAlumno.Inserta(entProfesorAlumno);
                if (profesorAlumno.IdProfAlum != 0)
                    return StatusCode(StatusCodes.Status200OK, new { mensaje = "ok", response = profesorAlumno });
                else
                    return StatusCode(StatusCodes.Status406NotAcceptable, new { mensaje = profesorAlumno.Mensaje, response = profesorAlumno });
            }
            catch (Exception error)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { mensaje = error.Message, response = profesorAlumno });
            }
        }
    }
}
