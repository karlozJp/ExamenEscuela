using Escuela.AccesoDatos.Data.Repository.IRepository;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace Escuela.API.Controllers
{
    [EnableCors("ReglasCors")]
    [Route("api/[controller]")]
    [ApiController]
    public class EscuelaController : Controller
    {
        private readonly IContenedorTrabajo _contenedorTrabajo;

        public EscuelaController(IContenedorTrabajo contenedorTrabajo)
        {
            _contenedorTrabajo = contenedorTrabajo;
        }

        [HttpGet]
        [Route("Consulta/{idEscuela:int}")]
        public IActionResult Consulta(int idEscuela) 
        {
            List<Modelos.Escuela> lstEscuela = new List<Modelos.Escuela>();
            try
            {
                lstEscuela = _contenedorTrabajo.Escuela.Consulta(idEscuela);
                if(lstEscuela.Count > 0)
                    return StatusCode(StatusCodes.Status200OK, new { mensaje = "ok", response = lstEscuela });
                else
                    return StatusCode(StatusCodes.Status406NotAcceptable, new { mensaje = "No se encontró información.", response = lstEscuela });
            }
            catch (Exception error)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { mensaje = error.Message, response = lstEscuela });
            }
        }

        [HttpPost]
        [Route("Inserta")]
        public IActionResult Inserta([FromBody] Modelos.Escuela entEscuela)
        {
            Modelos.Escuela escuela = new Modelos.Escuela();
            if (entEscuela == null)
            {
                return StatusCode(StatusCodes.Status404NotFound, new { mensaje = "Error al crear la escuela" });
            }
            try
            {
                escuela = _contenedorTrabajo.Escuela.Inserta(entEscuela);
                if(escuela.IdEscuela != 0)
                    return StatusCode(StatusCodes.Status200OK, new { mensaje = "ok", response = escuela });
                else
                    return StatusCode(StatusCodes.Status406NotAcceptable, new { mensaje = escuela.Mensaje, response = escuela });

            }
            catch (Exception error)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { mensaje = error.Message, response = escuela });
            }
        }

        [HttpPut]
        [Route("Actualiza")]
        public IActionResult Actualiza([FromBody]Modelos.Escuela entEscuela)
        {
            Modelos.Escuela escuela=new Modelos.Escuela();
            if (entEscuela == null)
            {
                return StatusCode(StatusCodes.Status404NotFound, new { mensaje = "Error al actualizar la escuela" });
            }
            try
            {
                escuela = _contenedorTrabajo.Escuela.Actualiza(entEscuela);
                if (escuela.IdEscuela != 0)
                    return StatusCode(StatusCodes.Status200OK,new { mensaje ="ok", response = escuela});
                else
                    return StatusCode(StatusCodes.Status406NotAcceptable, new { mensaje = escuela.Mensaje, response = escuela });
            }
            catch (Exception error) 
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { mensaje = error.Message, response = escuela });
            }
        }

        [HttpDelete]
        [Route("Elimina/{IdEscuela:int}")]
        public IActionResult Elimina(int IdEscuela)
        {
            var varescuela = _contenedorTrabajo.Escuela.Get(IdEscuela);
            Modelos.Escuela escuela = new Modelos.Escuela();
            try
            {
                if (varescuela == null)
                    StatusCode(StatusCodes.Status404NotFound, new { mensaje = "Error al eliminar la escuela." });
                escuela = _contenedorTrabajo.Escuela.Elimina(IdEscuela);
                if (escuela.IdEscuela != 0)
                    return StatusCode(StatusCodes.Status200OK, new { mensaje = "ok", response = escuela });
                else
                    return StatusCode(StatusCodes.Status406NotAcceptable, new { mensaje = escuela.Mensaje, response = escuela });
            }
            catch (Exception error)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { mensaje = error.Message, response = escuela });
            }
        }

    }
}
