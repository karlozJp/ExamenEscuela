using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Escuela.AccesoDatos.Data.Repository.IRepository
{
    public interface IContenedorTrabajo : IDisposable    // Implement IDisposable para liberar recursos cuando ya no se necesiten
    {
        //se crean las interfaces de los repositorios que se van a utilizar en el proyecto
        IEscuelaRepository Escuela { get; }
        IAlumnoRepository Alumno { get; } // Propiedad para acceder al repositorio de alumnos
        IProfesorRepository Profesor { get; } // Propiedad para acceder al repositorio de profesores
        IEscuelaProfesor EscuelaProfesor { get; } // Propiedad para acceder al repositorio de escuela-profesor
        IInscripcionRepository Inscripcion { get; } // Propiedad para acceder al repositorio de inscripciones
        IProfesorAlumnoRepository ProfesorAlumno { get; } // Propiedad para acceder al repositorio de profesor-alumno
        void Save(); // Método para guardar los cambios en la base de datos
    }
}
