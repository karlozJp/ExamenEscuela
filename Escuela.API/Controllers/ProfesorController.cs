using Escuela.AccesoDatos.Data.Repository.IRepository;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace Escuela.API.Controllers
{
    [EnableCors("ReglasCors")]
    [Route("api/[controller]")]
    [ApiController]
    public class ProfesorController : Controller
    {
        private readonly IContenedorTrabajo _contenedorTrabajo;

        public ProfesorController(IContenedorTrabajo contenedorTrabajo)
        {
            _contenedorTrabajo = contenedorTrabajo;
        }

        [HttpGet]
        [Route("Consulta/{idProfesor:int}")]
        public IActionResult Consulta(int idProfesor)
        {
            List<Modelos.Profesor> lstProfesor = new List<Modelos.Profesor>();
            try
            {
                lstProfesor = _contenedorTrabajo.Profesor.Consulta(idProfesor);
                if (lstProfesor.Count > 0)
                    return StatusCode(StatusCodes.Status200OK, new { mensaje = "ok", response = lstProfesor });
                else
                    return StatusCode(StatusCodes.Status406NotAcceptable, new { mensaje = "No se encontró información.", response = lstProfesor });
            }
            catch (Exception error)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { mensaje = error.Message, response = lstProfesor });
            }
        }

        [HttpPost]
        [Route("Inserta")]
        public IActionResult Inserta([FromBody] Modelos.Profesor entProfesor)
        {
            Modelos.Profesor profesor = new Modelos.Profesor();
            if (entProfesor == null)
            {
                return StatusCode(StatusCodes.Status404NotFound, new { mensaje = "Error al crear el profesor" });
            }
            try
            {
                profesor = _contenedorTrabajo.Profesor.Inserta(entProfesor);
                if (profesor.IdProfesor != 0)
                    return StatusCode(StatusCodes.Status200OK, new { mensaje = "ok", response = profesor });
                else
                    return StatusCode(StatusCodes.Status406NotAcceptable, new { mensaje = profesor.mensaje, response = profesor });
            }
            catch (Exception error)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { mensaje = error.Message, response = profesor });
            }
        }

        [HttpPost]
        [Route("Actualiza")]
        public IActionResult Actualiza([FromBody] Modelos.Profesor entProfesor)
        {
            Modelos.Profesor profesor = new Modelos.Profesor();
            if (entProfesor == null)
            {
                return StatusCode(StatusCodes.Status404NotFound, new { mensaje = "Error al actualizar el profesor" });
            }
            try
            {
                profesor = _contenedorTrabajo.Profesor.Actualiza(entProfesor);
                if (profesor.IdProfesor != 0)
                    return StatusCode(StatusCodes.Status200OK, new { mensaje = "ok", response = profesor });
                else
                    return StatusCode(StatusCodes.Status406NotAcceptable, new { mensaje = profesor.mensaje, response = profesor });
            }
            catch (Exception error)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { mensaje = error.Message, response = profesor });
            }
        }

        [HttpDelete]
        [Route("Elimina/{idProfesor:int}")]
        public IActionResult Elimina(int idProfesor)
        {
            var varprofesor = _contenedorTrabajo.Profesor.Get(idProfesor);
            Modelos.Profesor profesor = new Modelos.Profesor();
           
            try
            {
                if (varprofesor == null)
                {
                    return StatusCode(StatusCodes.Status404NotFound, new { mensaje = "No se encontró información del profesor" });
                }
                if (idProfesor == 0)
                {
                    return StatusCode(StatusCodes.Status404NotFound, new { mensaje = "Error al eliminar el profesor" });
                }
                profesor = _contenedorTrabajo.Profesor.Elimina(idProfesor);
                if (profesor.IdProfesor != 0)
                    return StatusCode(StatusCodes.Status200OK, new { mensaje = "ok", response = profesor });
                else
                    return StatusCode(StatusCodes.Status406NotAcceptable, new { mensaje = profesor.mensaje, response = profesor });
            }
            catch (Exception error)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { mensaje = error.Message, response = profesor });
            }
        }
    }
}
