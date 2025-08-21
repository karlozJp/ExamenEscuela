using Escuela.AccesoDatos.Data.Repository.IRepository;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;


namespace Escuela.API.Controllers
{
    [EnableCors("ReglasCors")]
    [Route("api/[controller]")]
    [ApiController]
    public class EscuelaProfesorController : Controller
    {
        private readonly IContenedorTrabajo _contenedorTrabajo;
        public EscuelaProfesorController(IContenedorTrabajo contenedorTrabajo)
        {
            _contenedorTrabajo = contenedorTrabajo;
        }
        [HttpGet]
        [Route("Consulta")]
        public IActionResult Consulta()
        {
            List<Modelos.EscuelaProfesor> lstEscProf = new List<Modelos.EscuelaProfesor>();
            try
            {
                lstEscProf = _contenedorTrabajo.EscuelaProfesor.Consulta();
                if (lstEscProf.Count > 0)
                    return StatusCode(StatusCodes.Status200OK, new { mensaje = "ok", response = lstEscProf });
                else
                    return StatusCode(StatusCodes.Status406NotAcceptable, new { mensaje = "No se encontró información.", response = lstEscProf });
            }
            catch (Exception error)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { mensaje = error.Message, response = lstEscProf });
            }
        }
        [HttpPost]
        [Route("Inserta")]
        public IActionResult Inserta([FromBody] Modelos.EscuelaProfesor entEscProf)
        {
            Modelos.EscuelaProfesor escuelaProfesor = new Modelos.EscuelaProfesor();
            if (entEscProf == null)
            {
                return StatusCode(StatusCodes.Status404NotFound, new { mensaje = "Error al crear la relación Escuela-Profesor" });
            }
            try
            {
                escuelaProfesor = _contenedorTrabajo.EscuelaProfesor.Inserta(entEscProf);
                if (escuelaProfesor.IdEscuelaProf != 0)
                    return StatusCode(StatusCodes.Status200OK, new { mensaje = "ok", response = escuelaProfesor });
                else
                    return StatusCode(StatusCodes.Status406NotAcceptable, new { mensaje = escuelaProfesor.Mensaje, response = escuelaProfesor });
            }
            catch (Exception error)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { mensaje = error.Message, response = escuelaProfesor });
            }
        }

    }
}
