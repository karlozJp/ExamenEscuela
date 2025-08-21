using Escuela.AccesoDatos.Data.Repository.IRepository;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace Escuela.API.Controllers
{
    [EnableCors("ReglasCors")]
    [Route("api/[controller]")]
    [ApiController]
    public class InscripcionController : Controller
    {
        private readonly IContenedorTrabajo _contenedorTrabajo;
        public InscripcionController(IContenedorTrabajo contenedorTrabajo)
        {
            _contenedorTrabajo = contenedorTrabajo;
        }

        [HttpGet]
        [Route("Consulta/{idInscripcion:int}")]

        public IActionResult Consulta(int idInscripcion)
        {
            List<Modelos.Inscripcion> lstInscripcion = new List<Modelos.Inscripcion>();
            try
            {
                lstInscripcion = _contenedorTrabajo.Inscripcion.Consulta(idInscripcion);
                if (lstInscripcion.Count > 0)
                    return StatusCode(StatusCodes.Status200OK, new { mensaje = "ok", response = lstInscripcion });
                else
                    return StatusCode(StatusCodes.Status406NotAcceptable, new { mensaje = "No se encontró información.", response = lstInscripcion });
            }
            catch (Exception error)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { mensaje = error.Message, response = lstInscripcion });
            }
        }

        [HttpPost]
        [Route("Inserta")]
        public IActionResult Inserta([FromBody] Modelos.Inscripcion entInscripcion)
        {
            Modelos.Inscripcion inscripcion = new Modelos.Inscripcion();
            if (entInscripcion == null)
            {
                return StatusCode(StatusCodes.Status404NotFound, new { mensaje = "Error al crear la inscripción" });
            }
            try
            {
                inscripcion = _contenedorTrabajo.Inscripcion.Inserta(entInscripcion);
                if (inscripcion.IdInscripcion != 0)
                    return StatusCode(StatusCodes.Status200OK, new { mensaje = "ok", response = inscripcion });
                else
                    return StatusCode(StatusCodes.Status406NotAcceptable, new { mensaje = inscripcion.Mensaje, response = inscripcion });
            }
            catch (Exception error)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { mensaje = error.Message, response = inscripcion });
            }
        }

    }
}
