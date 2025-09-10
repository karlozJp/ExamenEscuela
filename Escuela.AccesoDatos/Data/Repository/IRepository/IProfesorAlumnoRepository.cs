using Escuela.Modelos;

namespace Escuela.AccesoDatos.Data.Repository.IRepository
{
    public interface IProfesorAlumnoRepository: IRepository<ProfesorAlumno>
    {   
        List<ProfesorAlumno> Consulta(int idProfesor);
        ProfesorAlumno Inserta(ProfesorAlumno entProfesorAlumno);
    }
}
