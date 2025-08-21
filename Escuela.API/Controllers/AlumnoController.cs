using Escuela.AccesoDatos.Data.Repository.IRepository;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace Escuela.API.Controllers
{
    [EnableCors("ReglasCors")]
    [Route("api/[controller]")]
    [ApiController]
    public class AlumnoController : Controller
    {
        private readonly IContenedorTrabajo _contenedorTrabajo;
        public AlumnoController(IContenedorTrabajo contenedorTrabajo)
        {
            _contenedorTrabajo = contenedorTrabajo;
        }

        [HttpGet]
        [Route("Consulta/{idAlumno:int}")]
        public IActionResult Consulta(int idAlumno)
        {
            List<Modelos.Alumno> lstAlumno = new List<Modelos.Alumno>();
            try
            {
                lstAlumno = _contenedorTrabajo.Alumno.Consulta(idAlumno);
                if (lstAlumno.Count > 0)
                    return StatusCode(StatusCodes.Status200OK, new { mensaje = "ok", response = lstAlumno });
                else
                    return StatusCode(StatusCodes.Status406NotAcceptable, new { mensaje = "No se encontró información.", response = lstAlumno });
            }
            catch (Exception error)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { mensaje = error.Message, response = lstAlumno });
            }
        }

        [HttpPost]
        [Route("Inserta")]
        public IActionResult Inserta([FromBody] Modelos.Alumno entAlumno)
        {
            Modelos.Alumno alumno = new Modelos.Alumno();
            if (entAlumno == null)
            {
                return StatusCode(StatusCodes.Status404NotFound, new { mensaje = "Error al crear el alumno" });
            }
            try
            {
                alumno = _contenedorTrabajo.Alumno.Inserta(entAlumno);
                if (alumno.IdAlumno != 0)
                    return StatusCode(StatusCodes.Status200OK, new { mensaje = "ok", response = alumno });
                else
                    return StatusCode(StatusCodes.Status406NotAcceptable, new { mensaje = alumno.Mensaje, response = alumno });
            }
            catch (Exception error)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { mensaje = error.Message, response = alumno });
            }
        }

        [HttpPut]
        [Route("Actualiza")]
        public IActionResult Actualiza([FromBody] Modelos.Alumno entAlumno)
        {
            Modelos.Alumno alumno = new Modelos.Alumno();
            if (entAlumno == null)
            {
                return StatusCode(StatusCodes.Status404NotFound, new { mensaje = "Error al actualizar el alumno" });
            }
            try
            {
                alumno = _contenedorTrabajo.Alumno.Actualiza(entAlumno);
                if (alumno.IdAlumno != 0)
                    return StatusCode(StatusCodes.Status200OK, new { mensaje = "ok", response = alumno });
                else
                    return StatusCode(StatusCodes.Status406NotAcceptable, new { mensaje = alumno.Mensaje, response = alumno });
            }
            catch (Exception error)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { mensaje = error.Message, response = alumno });
            }
        }

        [HttpDelete]
        [Route("Elimina/{idAlumno:int}")]
        public IActionResult Elimina(int idAlumno)
        {
            var varescuela = _contenedorTrabajo.Alumno.Get(idAlumno);
            Modelos.Alumno alumno = new Modelos.Alumno();            
            try
            {
                if (varescuela == null)
                    return StatusCode(StatusCodes.Status404NotFound, new { mensaje = "No se encontró el alumno a eliminar." });
                alumno = _contenedorTrabajo.Alumno.Elimina(idAlumno);
                if (alumno.IdAlumno != 0)
                    return StatusCode(StatusCodes.Status200OK, new { mensaje = "ok", response = alumno });
                else
                    return StatusCode(StatusCodes.Status406NotAcceptable, new { mensaje = alumno.Mensaje, response = alumno });
            }
            catch (Exception error)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { mensaje = error.Message, response = alumno });
            }
        }
    }
}
